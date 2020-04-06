using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class Panboo_HealthBar : MonoBehaviour
{
    //Reference to both heathbar images
    private Image BarImage;
    private Image BarImagemy;

    public Text MyHPText;
    public Text EmeHPText;
    public Text Attack5Text;
    public Text Attack6Text;
    public Text ExpText;
    public Button Attack5;
    public Button Attack6;


    //Links the two hero classes.
    private Panboo_EneHealth PanbooEnemyHealth;
    private Panboo_Health PanbooHealth;
    private LevelSystem levelSystem;

    private int moreEnemyhealth = keephealthEnemy;
    private static int keephealthEnemy = 0;
    private int EnemyAttackIncseLevel = EnemyKeepAttackState;
    private static int EnemyKeepAttackState = 0;
    private int EnemyDefenceIncseLevel = EnemyKeepDefenceState;
    private static int EnemyKeepDefenceState = 0;

    private int morehealth = keephealth;
    private static int keephealth = 0;
    private int AttackIncseLevel = KeepAttackState;
    private static int KeepAttackState = 0;
    private int DefenceIncseLevel = KeepDefenceState;
    private static int KeepDefenceState = 0;

    private void Awake()
    {
        //Gets the reference to both healthbar images.
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();
    }

    private void Update()
    {
        EmeTextChange();
        MyTextChange();
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
            Attack5Text.text = "Water Gun v2";
        else
            Attack5Text.text = "Locked";

        if (levelSystem.Level >= 5)
            Attack6Text.text = "Water Gun v2";
        else
            Attack6Text.text = "Locked";
    }
    private void Start()
    {
        EnemyMoreHealth();
        MoreHealth();

        //start a new health system with 100 Health for both heros.
        PanbooEnemyHealth = new Panboo_EneHealth(100 + keephealthEnemy);
        PanbooHealth = new Panboo_Health(100 + keephealth);

        //Get the healthNormalized
        SetHealth(PanbooEnemyHealth.GetHealthNormalized());
        MySetHealth(PanbooHealth.MyGetHealthNormalized());

        //Update the health on damage.
        PanbooEnemyHealth.OnDamaged += EneHealthSystem_OnDamaged;
        PanbooHealth.OnDamaged += MyHealthSystem_OnDamaged;


        //Update the health on heal.
        PanbooEnemyHealth.OnHealed += EneHealthSystem_OnHealed;
        PanbooHealth.OnHealed += MyHealthSystem_OnHealed;
    }

    public void EnemyMoreHealth()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            moreEnemyhealth += morehealth / 2;
            keephealthEnemy = moreEnemyhealth;
            EnemyAttackIncseLevel += AttackIncseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            moreEnemyhealth += Random.Range(5, 15);
            keephealthEnemy = moreEnemyhealth;
            EnemyAttackIncseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncseLevel;
        }
        else
        {
            moreEnemyhealth = keephealthEnemy;
        }
    }

    public void MoreHealth()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 2 == 0)
        {
            morehealth += Random.Range(3, 8);
            keephealth = morehealth;
            AttackIncseLevel += Random.Range(3, 8);
            KeepAttackState = AttackIncseLevel;
            DefenceIncseLevel += Random.Range(1, 3);
            KeepDefenceState = DefenceIncseLevel;
        }
        else
        {
            AttackIncseLevel = KeepAttackState;
            morehealth = keephealth;
            DefenceIncseLevel = KeepDefenceState;
        }
    }

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        Debug.Log("Hero Healed");

        PanbooHealth.Heal(Random.Range(10, 30));
        Enemychoice();
        MyTextChange();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        PanbooEnemyHealth.Damage(5 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        PanbooEnemyHealth.Damage(10 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        PanbooEnemyHealth.Damage(15 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        PanbooEnemyHealth.Damage(10 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = true;
            PanbooEnemyHealth.Damage(12 + KeepAttackState);
            Enemychoice();
            MyTextChange();
        }
        else
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = false;
        }
    }

    public void Attack_6()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 9)
        {
            transform.Find("Attack6Button").GetComponent<Button>().interactable = true;
            PanbooEnemyHealth.Damage(12 + KeepAttackState);
            Enemychoice();
            MyTextChange();
        }
        else
        {
            transform.Find("Attack6Button").GetComponent<Button>().interactable = false;
        }
    }

    public void EmeTextChange()
    {
        EmeHPText.text = PanbooEnemyHealth.emeHPTextReturn();
    }

    public void MyTextChange()
    {
        MyHPText.text = PanbooHealth.MyHPTextReturn();
    }

    //This is the where the enemy deals damage to our system, while also having a 1 in 4 changes to heal itself.
    public void Enemychoice()
    {
        int randomnumnber;
        //Generate random number between 1 to 5.
        randomnumnber = Random.Range(1, 5);

        //If the generate number is 2, the enemy hero would heal.
        if (randomnumnber == 2)
        {
            
            PanbooEnemyHealth.Heal((30));
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            
            PanbooHealth.Damage(Random.Range(1, 20) + EnemyKeepAttackState - KeepDefenceState);
            EmeTextChange();
        }
    }

    //Trigger by an event on the enemy health systyem.s
    private void EneHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(PanbooEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        MySetHealth(PanbooHealth.MyGetHealthNormalized());
    }

    //Trigger by an event on the enemy health systyem.
    private void EneHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(PanbooEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        MySetHealth(PanbooHealth.MyGetHealthNormalized());
    }

    //Changes the bar image for the enemy's health.
    private void SetHealth(float healthNormalized)
    {
        BarImage.fillAmount = healthNormalized;
    }

    //Changes the bar image for the our hero health.
    private void MySetHealth(float MyhealthNormalized)
    {
        BarImagemy.fillAmount = MyhealthNormalized;
    }
}
