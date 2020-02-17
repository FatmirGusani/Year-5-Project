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


    //Links the two hero classes.
    private EmeHealthSystem emehealthSystem;
    private MyHealthSystem MyhealthSystem;

    private void Awake()
    {
        //Gets the reference to both healthbar images.
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();
    }
    private void Start()
    {
        //start a new health system with 100 Health for both heros.
        emehealthSystem = new EmeHealthSystem(100);
        MyhealthSystem = new MyHealthSystem(100);

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

    //The hero Heal function. Once the button is pressed, this function will run.
    public void HealHero()
    {
        Debug.Log("Hero Healed");
        
        MyhealthSystem.Heal(Random.Range(10, 30));
        Enemychoice();
        MyTextChange();
    }

    //Attack move 1. When button is pressed, call this function.
    public void Attack_1()
    {
        emehealthSystem.Damage(7);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 2. When button is pressed, call this function.
    public void Attack_2()
    {
        emehealthSystem.Damage(15);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 3. When button is pressed, call this function.
    public void Attack_3()
    {
        emehealthSystem.Damage(20);
        Enemychoice();
        MyTextChange();
    }

    //Attack move 4. When button is pressed, call this function.
    public void Attack_4()
    {
        emehealthSystem.Damage(15);
        Enemychoice();
        MyTextChange();
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
            Debug.Log("Heal");
            emehealthSystem.Heal((30));
            EmeTextChange();
        }
        else
        {
            //otherwise it would attack.
            Debug.Log("Damage");
            MyhealthSystem.Damage(Random.Range(5, 25));
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
