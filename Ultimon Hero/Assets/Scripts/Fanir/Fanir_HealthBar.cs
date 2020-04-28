using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Fanir_HealthBar : MonoBehaviour
{
    //Reference to both heathbar images
    private Image BarImage;
    private Image BarImagemy;
    private Image CircleDamage;

    public Text MyHPText;
    public Text EmeHPText;
    public Text DamageText;
    public Text Attack5Text;
    public Text Attack6Text;

    //Links the two hero classes.
    private Fanir_EneHealth FanirEnemyHealth;
    private Fanir_Health FanirHealth;

    public void Awake()
    {
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();
        CircleDamage = transform.Find("CircleDamage").GetComponent<Image>();
    }

    void Update()
    {
        MyTextChange();
        EmeTextChange();
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
            Attack5Text.text = "Tsunami";
        else
            Attack5Text.text = "Locked";

        if (levelSystem.Level >= 5)
            Attack6Text.text = "Icicle";
        else
            Attack6Text.text = "Locked";
    }

    private void Start()
    {
        CircleDamage.enabled = false;
        DamageText.enabled = false;

        HeroLevelStats Fanir_States = new HeroLevelStats();
        EnemyLevelStats enemyLevelStats = new EnemyLevelStats();

        Fanir_States.LagoonStatesLevel();
        enemyLevelStats.LagoonEnemyStatesLevel();

        FanirEnemyHealth = new Fanir_EneHealth(100 + EnemyLevelStats.EnemyKeepHealthState);
        FanirHealth = new Fanir_Health(110 + HeroLevelStats.KeepHealthState);

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
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());
        FanirHealth.Heal(Random.Range(10, 30));

        CircleDamage.enabled = true;
        DamageText.enabled = true;
        CircleDamage.color = Color.blue;
        ValueToHero();
        Delay();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        CircleDamage.enabled = true;
        DamageText.enabled = true;

        FanirEnemyHealth.Damage(5 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        CircleDamage.enabled = true;
        DamageText.enabled = true;

        FanirEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        CircleDamage.enabled = true;
        DamageText.enabled = true;

        FanirEnemyHealth.Damage(60 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        CircleDamage.enabled = true;
        DamageText.enabled = true;

        FanirEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }
    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            transform.Find("Attack5Button").GetComponent<Button>().interactable = true;
            ButtonDelay buttonDelay = new ButtonDelay();
            StartCoroutine(buttonDelay.ButtonAttackDelay());

            CircleDamage.enabled = true;
            DamageText.enabled = true;

            FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
            CircleDamage.color = Color.green;
            ValueToEnemy();
            Delay();
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
            ButtonDelay buttonDelay = new ButtonDelay();
            StartCoroutine(buttonDelay.ButtonAttackDelay());

            CircleDamage.enabled = true;
            DamageText.enabled = true;

            FanirEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
            CircleDamage.color = Color.green;
            ValueToEnemy();
            Delay();
        }
        else
        {
            transform.Find("Attack6Button").GetComponent<Button>().interactable = false;
        }
    }

    public void Delay()
    {
        Invoke("Enemychoice", 1);
        Invoke("MyTextChange", 1);
    }

    //This is the where the enemy deals damage to our system, while also having a 1 in 4 changes to heal itself.
    public void Enemychoice()
    {
        int randomnumnber;
        //Generate random number between 1 to 5.
        randomnumnber = Random.Range(1, 5);

        //If the generate number is 2, the enemy hero would heal.
        if (randomnumnber == 3)
        {
            FanirEnemyHealth.Heal((30));
            CircleDamage.color = Color.yellow;
            ValueToEnemy();
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            FanirHealth.Damage(Random.Range(5, 25) + EnemyLevelStats.EnemyKeepAttackState - HeroLevelStats.KeepDefenceState);
            CircleDamage.color = Color.red;
            ValueToHero();
            EmeTextChange();
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

    public void ValueToHero()
    {
        DamageText.text = FanirHealth.amountValue.ToString();
    }

    public void ValueToEnemy()
    {
        DamageText.text = FanirEnemyHealth.amountValue.ToString();
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
