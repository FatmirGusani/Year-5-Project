using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Lagoon_HealthBar : MonoBehaviour
{
    //Reference to both heathbar images
    private Image BarImage;
    private Image BarImagemy;

    public Text MyHPText;
    public Text EmeHPText;
    public Text Attack5Text;
    public Text Attack6Text;
    public Button Attack5;
    public Button Attack6;

    //Links the two hero classes.
    private Lagoon_EneHealth lagoonEnemyHealth;
    private Lagoon_Health lagoonHealth;
    private Lagoon lagoon;
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

    public void Awake()
    {
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();
    }

    void Update()
    {
        MyTextChange();
        EmeTextChange();
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
        //start a new health system with 100 Health for both heros.
        MoreHealth();
        EnemyMoreHealth();
        //MyTextChange();
        Lagoon lagoon = new Lagoon();

        lagoonEnemyHealth = new Lagoon_EneHealth(100 + keephealthEnemy);
        lagoonHealth = new Lagoon_Health(120 + keephealth);

        //Get the healthNormalized
        SetHealth(lagoonEnemyHealth.GetHealthNormalized());
        MySetHealth(lagoonHealth.MyGetHealthNormalized());

        //Update the health on damage.
        lagoonEnemyHealth.OnDamaged += EneHealthSystem_OnDamaged;
        lagoonHealth.OnDamaged += MyHealthSystem_OnDamaged;


        //Update the health on heal.
        lagoonEnemyHealth.OnHealed += EneHealthSystem_OnHealed;
        lagoonHealth.OnHealed += MyHealthSystem_OnHealed;
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

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        lagoonHealth.Heal(Random.Range(10, 30));
        Enemychoice();
        MyTextChange();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        lagoonEnemyHealth.Damage(5 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        lagoonEnemyHealth.Damage(10 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        lagoonEnemyHealth.Damage(80 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        lagoonEnemyHealth.Damage(10 + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    
    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = true;
            lagoonEnemyHealth.Damage(12);
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
            lagoonEnemyHealth.Damage(12);
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
        EmeHPText.text = lagoonEnemyHealth.emeHPTextReturn();
    }

    public void MyTextChange()
    {
        MyHPText.text = lagoonHealth.MyHPTextReturn();
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
            lagoonEnemyHealth.Heal((30));
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            lagoonHealth.Damage(Random.Range(5, 25) + EnemyKeepAttackState - KeepDefenceState);
            EmeTextChange();
        }
    }

    public void CheckAttack5()
    {
        if (levelSystem.Level == 2)
        {
            Attack5.gameObject.SetActive(false);

        }
    }

    //Trigger by an event on the enemy health systyem.s
    private void EneHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(lagoonEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        MySetHealth(lagoonHealth.MyGetHealthNormalized());
    }

    //Trigger by an event on the enemy health systyem.
    private void EneHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(lagoonEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        MySetHealth(lagoonHealth.MyGetHealthNormalized());
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
