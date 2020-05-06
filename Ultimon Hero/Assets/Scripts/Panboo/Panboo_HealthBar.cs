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
    private Image CircleDamage;

    public Text MyHPText;
    public Text EmeHPText;
    public Text DamageText;
    public Text Attack5Text;
    public Text Attack6Text;

    //Links the two hero classes.
    private Panboo_EneHealth PanbooEnemyHealth;
    private Panboo_Health PanbooHealth;

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

        HeroLevelStats Panboo_States = new HeroLevelStats();
        EnemyLevelStats enemyLevelStats = new EnemyLevelStats();

        Panboo_States.PanbooStatesLevel();
        enemyLevelStats.PanbooEnemyStatesLevel();

        PanbooEnemyHealth = new Panboo_EneHealth(100 + EnemyLevelStats.EnemyKeepHealthState);
        PanbooHealth = new Panboo_Health(100 + HeroLevelStats.KeepHealthState);

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

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());
        PanbooHealth.Heal(Random.Range(10, 30));

        StartCoroutine(DamageBox());

        CircleDamage.color = Color.blue;
        ValueToHero();
        Delay();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        StartCoroutine(DamageBox());

        PanbooEnemyHealth.Damage(5 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        StartCoroutine(DamageBox());

        PanbooEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        StartCoroutine(DamageBox());

        PanbooEnemyHealth.Damage(15 + HeroLevelStats.KeepAttackState);
        CircleDamage.color = Color.green;
        ValueToEnemy();
        Delay();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        ButtonDelay buttonDelay = new ButtonDelay();
        StartCoroutine(buttonDelay.ButtonAttackDelay());

        StartCoroutine(DamageBox());

        PanbooEnemyHealth.Damage(10 + HeroLevelStats.KeepAttackState);
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

            StartCoroutine(DamageBox());

            PanbooEnemyHealth.Damage(17 + HeroLevelStats.KeepAttackState);
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

            StartCoroutine(DamageBox());

            PanbooEnemyHealth.Damage(20 + HeroLevelStats.KeepAttackState);
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
    IEnumerator DamageBox()
    {
        CircleDamage.enabled = true;
        DamageText.enabled = true;
        yield return new WaitForSeconds(2.0f);
        CircleDamage.enabled = false;
        DamageText.enabled = false;
    }

    //This is the where the enemy deals damage to our system, while also having a 1 in 4 changes to heal itself.
    public void Enemychoice()
    {
        int randomnumnber;
        //Generate random number between 1 to 5.
        randomnumnber = Random.Range(1, 8);

        //If the generate number is 2, the enemy hero would heal.
        if (randomnumnber == 3)
        {
            PanbooEnemyHealth.Heal((30));
            CircleDamage.color = Color.yellow;
            ValueToEnemy();
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            PanbooHealth.Damage(Random.Range(5, 20) + EnemyLevelStats.EnemyKeepAttackState - HeroLevelStats.KeepDefenceState);
            CircleDamage.color = Color.red;
            ValueToHero();
            EmeTextChange();
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

    public void ValueToHero()
    {
        DamageText.text = PanbooHealth.amountValue.ToString();
    }

    public void ValueToEnemy()
    {
        DamageText.text = PanbooEnemyHealth.amountValue.ToString();
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
