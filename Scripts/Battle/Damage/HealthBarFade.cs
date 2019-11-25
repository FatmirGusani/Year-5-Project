using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey;
using CodeMonkey.Utils;
using System.Threading.Tasks;

public class HealthBarFade : MonoBehaviour
{

    private Image BarImage;
    private Image BarImagemy;

    private HealthSystem healthSystem;
    private MyHealthSystem MyhealthSystem;

    public Text MyLevel;

    public int MyLevel7 = 7;

    private void Awake()
    {
        BarImage = transform.Find("HPBar").GetComponent<Image>();
        BarImagemy = transform.Find("MyHPBar").GetComponent<Image>();
        MyLevel = transform.Find("Level").GetComponent<Text>();
        
    }

    private void Start()
    {
        healthSystem = new HealthSystem(100);
        MyhealthSystem = new MyHealthSystem(100);

        SetHealth(healthSystem.GetHealthNormalized());
        MySetHealth(MyhealthSystem.MyGetHealthNormalized());

        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        MyhealthSystem.OnDamaged += MyHealthSystem_OnDamaged;
    }

    public void Wing_Slap()
    {
        healthSystem.Damage(7);
        //Task.Delay(20000);


        MyhealthSystem.Damage(Random.Range(5,20));
    }

    public void FlameThrower()
    {
        healthSystem.Damage(15);
        //Debug.log(Texttry());
        Texttry();
        MyhealthSystem.Damage(Random.Range(5, 20));
    }

    public void Solar_Flare()
    {
        healthSystem.Damage(20);
        MyhealthSystem.Damage(Random.Range(5, 20));
    }

    public void Dragon_Slash()
    {
        healthSystem.Damage(15);
        MyhealthSystem.Damage(Random.Range(5, 20));
    }


    private void HealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        SetHealth(healthSystem.GetHealthNormalized());
    }

    private void MyHealthSystem_OnDamaged(object sender, System.EventArgs e)
    {
        MySetHealth(MyhealthSystem.MyGetHealthNormalized());
    }

    private void SetHealth(float healthNormalized)
    {
        BarImage.fillAmount = healthNormalized;
    }

    private void MySetHealth(float MyhealthNormalized)
    {
        BarImagemy.fillAmount = MyhealthNormalized;
    }

    void Texttry()
    {
        MyLevel.text = "level :" + MyLevel7.ToString();
    }
}
