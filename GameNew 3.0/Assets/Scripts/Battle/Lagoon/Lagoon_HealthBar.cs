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


    //Links the two hero classes.
    private Lagoon_EneHealth lagoonEnemyHealth;
    private Lagoon_Health lagoonHealth;
    private Lagoon lagoon;
    private LevelSystem levelSystem;


    private int morehealth = keephealth;
    private static int keephealth = 0;
    private int moreEnemyhealth = keephealthEnemy;
    private static int keephealthEnemy = 0;

    public void Awake()
    {
        //Gets the reference to both healthbar images.
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();

        //SHP= lagoon.sendhealth;
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
            morehealth += 10;
            keephealth = morehealth;
        }
        else
        {
            morehealth = keephealth;
        }
    }

    public void EnemyMoreHealth()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 2 == 0)
        {
            moreEnemyhealth += Random.Range(5, 15);
            keephealthEnemy = moreEnemyhealth;
        }
        else
        {
            Random.Range(5, 15);
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
        lagoonEnemyHealth.Damage(5);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        lagoonEnemyHealth.Damage(10);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        lagoonEnemyHealth.Damage(80);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        lagoonEnemyHealth.Damage(10);
        Enemychoice();
        MyTextChange();
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
            lagoonHealth.Damage(Random.Range(5, 25));
            EmeTextChange();
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
