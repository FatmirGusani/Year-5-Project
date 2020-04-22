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

public class Fanir_HealthBar : MonoBehaviour
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
    private Fanir_EneHealth FanirEnemyHealth;
    private Fanir_Health FanirHealth;
    private LevelSystem levelSystem;
    private HeroLevelStats heroLevelStats;
    private EnemyLevelStats enemyLevelStats;

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
            Attack5Text.text = "Dive Boom";
        else
            Attack5Text.text = "Locked";

        if (levelSystem.Level >= 5)
            Attack6Text.text = "Eruption";
        else
            Attack6Text.text = "Locked";
    }
    private void Start()
    {
        HeroLevelStats Fanir_States = new HeroLevelStats();
        EnemyLevelStats enemyLevelStats = new EnemyLevelStats();

        Fanir_States.FanirStatesLevel();
        enemyLevelStats.FanirEnemyStatesLevel();

        //start a new health system with 100 Health for both heros.
        FanirEnemyHealth = new Fanir_EneHealth(100 + EnemyLevelStats.EnemyKeepHealthState);
        FanirHealth = new Fanir_Health(100 + HeroLevelStats.KeepHealthState);

        //Get the healthNormalized
        SetHealth(FanirEnemyHealth.GetHealthNormalized());
        MySetHealth(FanirHealth.MyGetHealthNormalized());

        //Update the health on damage.
        FanirEnemyHealth.OnDamaged += EneHealthSystem_OnDamaged;
        FanirHealth.OnDamaged += MyHealthSystem_OnDamaged;

        //Update the health on heal.
        FanirEnemyHealth.OnHealed += EneHealthSystem_OnHealed;
        FanirHealth.OnHealed += MyHealthSystem_OnHealed;
    }

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        FanirHealth.Heal(Random.Range(10, 30));
        Enemychoice();
        MyTextChange();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        FanirEnemyHealth.Damage(7 + HeroLevelStats.KeepAttackState);
        Debug.Log("Attack 1 power" + HeroLevelStats.KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
        Debug.Log("Attack 2 power" + HeroLevelStats.KeepAttackState);
        
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        FanirEnemyHealth.Damage(17 + HeroLevelStats.KeepAttackState);
        Debug.Log("Attack 3 power" + HeroLevelStats.KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
        Debug.Log("Attack 4 power" + HeroLevelStats.KeepAttackState);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 5. When button is pressed, call this function.
    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = true;
            FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
            Enemychoice();
            MyTextChange();
        }
        else
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = false;
        }
    }

    //Attack move 6. When button is pressed, call this function.
    public void Attack_6()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 9)
        {
            transform.Find("Attack6Button").GetComponent<Button>().interactable = true;
            FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
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
        EmeHPText.text = FanirEnemyHealth.emeHPTextReturn();
    }

    public void MyTextChange()
    {
        MyHPText.text = FanirHealth.MyHPTextReturn();
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
            FanirEnemyHealth.Heal((30));
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            FanirHealth.Damage(Random.Range(5, 25) + EnemyLevelStats.EnemyKeepAttackState - HeroLevelStats.KeepDefenceState);
            Debug.Log("Test Attack" + EnemyLevelStats.EnemyKeepAttackState);
            Debug.Log("Test Defence" + HeroLevelStats.KeepDefenceState);
            EmeTextChange();
        }
    }

    //Trigger by an event on the enemy health systyem.s
    private void EneHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(FanirEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        MySetHealth(FanirHealth.MyGetHealthNormalized());
    }

    //Trigger by an event on the enemy health systyem.
    private void EneHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        SetHealth(FanirEnemyHealth.GetHealthNormalized());
    }

    //Trigger by an event on the our health systyem.
    private void MyHealthSystem_OnHealed(object sender, System.EventArgs e)
    {
        MySetHealth(FanirHealth.MyGetHealthNormalized());
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
