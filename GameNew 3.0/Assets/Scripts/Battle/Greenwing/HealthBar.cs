using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;
using System.Threading.Tasks;

//This code will display the damage done to the Heros using the green bar in the battle screen.
//The attack moves functions are created here and our hero uses these fucntions to deal damage to the enemy hero.
//Once our hero deals damage, the enemy hero will also deal damage to our hero using a random call. the damage is ranged from 5 to 20.
//Our heal can also heal, the heal function use the random.range aswell. the range for our heal is from 10 - 30.
//If our hero heals, the enemy will also attack. If the heal is higher value then the enemy damage, the healthbar will go up,
//otherwise the damage done will be higher then the heal value and our healthbar will go down.

public class HealthBar : MonoBehaviour
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
    private EmeHealthSystem emehealthSystem;
    private MyHealthSystem MyhealthSystem;
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
        emehealthSystem = new EmeHealthSystem(100 + keephealthEnemy);
        MyhealthSystem = new MyHealthSystem(100 + keephealth);

        //Get the healthNormalized
        SetHealth(emehealthSystem.GetHealthNormalized());
        MySetHealth(MyhealthSystem.MyGetHealthNormalized());

        //Update the health on damage.
        emehealthSystem.OnDamaged += EneHealthSystem_OnDamaged;
        MyhealthSystem.OnDamaged += MyHealthSystem_OnDamaged;
      

        //Update the health on heal.
        emehealthSystem.OnHealed += EneHealthSystem_OnHealed;
        MyhealthSystem.OnHealed += MyHealthSystem_OnHealed;
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
        MyhealthSystem.Heal(Random.Range(10, 30));
        Enemychoice();
        MyTextChange();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        emehealthSystem.Damage(7 + KeepAttackState);
        Debug.Log("Attack 1 power" + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        emehealthSystem.Damage(15 + KeepAttackState);
        Debug.Log("Attack 2 power" + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        emehealthSystem.Damage(20 + KeepAttackState);
        Debug.Log("Attack 3 power" + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        emehealthSystem.Damage(15 + KeepAttackState);
        Debug.Log("Attack 4 power" + KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = true;
            emehealthSystem.Damage(12);
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
            emehealthSystem.Damage(12);
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
        EmeHPText.text = emehealthSystem.emeHPTextReturn();
    }

    public void MyTextChange()
    {
        MyHPText.text = MyhealthSystem.MyHPTextReturn();
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
            emehealthSystem.Heal((30));
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            MyhealthSystem.Damage(Random.Range(5, 25) + EnemyKeepAttackState - KeepDefenceState);
            Debug.Log("Test Attack" + EnemyKeepAttackState);
            Debug.Log("Test Defence" + KeepDefenceState);
            EmeTextChange();
        }
    }

    //Trigger by an event on the enemy health systyem.s
    private void EneHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(emehealthSystem.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        MySetHealth(MyhealthSystem.MyGetHealthNormalized());
    }

    //Trigger by an event on the enemy health systyem.
    private void EneHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(emehealthSystem.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        MySetHealth(MyhealthSystem.MyGetHealthNormalized());
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
