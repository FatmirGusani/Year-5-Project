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
    private Image CircleDamage;

    public Text MyHPText;
    public Text EmeHPText;
    public Text DamageText;
    public Text Attack5Text;
    public Text Attack6Text;

    //Links the two hero classes.
    private Lagoon_EneHealth lagoonEnemyHealth;
    private Lagoon_Health lagoonHealth;

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

        HeroLevelStats Lagoon_States = new HeroLevelStats();
        EnemyLevelStats enemyLevelStats = new EnemyLevelStats();

        Lagoon_States.LagoonStatesLevel();
        enemyLevelStats.LagoonEnemyStatesLevel();

        lagoonEnemyHealth = new Lagoon_EneHealth(100 + EnemyLevelStats.EnemyKeepHealthState);
        lagoonHealth = new Lagoon_Health(110 + HeroLevelStats.KeepHealthState);

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

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());
        lagoonHealth.Heal(Random.Range(10, 30));

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

        lagoonEnemyHealth.Damage(5 + HeroLevelStats.KeepAttackState);
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

        lagoonEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
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

        lagoonEnemyHealth.Damage(60 + HeroLevelStats.KeepAttackState);
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

        lagoonEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }
    public void Attack_5()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2)
        {
            ButtonDelay buttonDelay = new ButtonDelay();
            StartCoroutine(buttonDelay.ButtonAttackDelay());

            CircleDamage.enabled = true;
            DamageText.enabled = true;

            lagoonEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
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

            lagoonEnemyHealth.Damage(12 + HeroLevelStats.KeepAttackState);
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
            lagoonEnemyHealth.Heal((30));
            CircleDamage.color = Color.yellow;
            ValueToEnemy();
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            lagoonHealth.Damage(Random.Range(5, 25) + EnemyLevelStats.EnemyKeepAttackState - HeroLevelStats.KeepDefenceState);
            CircleDamage.color = Color.red;
            ValueToHero();
            EmeTextChange();
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

    public void ValueToHero()
    {
        DamageText.text = lagoonHealth.amountValue.ToString();
        Debug.Log("amountValue :" + lagoonHealth.amountValue);
    }

    public void ValueToEnemy()
    {
        DamageText.text = lagoonEnemyHealth.amountValue.ToString();
        Debug.Log("amountValue :" + lagoonEnemyHealth.amountValue);
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
