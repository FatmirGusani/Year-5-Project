using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Award : MonoBehaviour
{
    private Fanir_EneHealth fanir_EneHealth;
    private Lagoon_EneHealth lagoon_EneHealth;
    private Panboo_EneHealth panboo_EneHealth;

    private int rand;

    public Sprite[] Spawner_Pic;

    private string[] Name = { "Toatone", "Croros", "Crazekey", "Ramparak", "Lobsteroid", "Pandyle", "Waroda", "Chickombo", "Dradrill", "Hunteleon", "Mermantis", "Super Panboo" };

    public Text EnemyName;
    public Text EnemyLevel;

    private void Awake()
    {
        EnemyName = transform.Find("EnemyName").GetComponent<Text>();
        EnemyLevel = transform.Find("EnemyLevel").GetComponent<Text>();
    }

    public void TestGameBeat()
    {
        if(fanir_EneHealth.dead == true)
        {
            Debug.Log("GOT HERE");
        }
    }
    // && lagoon_EneHealth.dead == true && lagoon_EneHealth.dead == true)


    // Start is called before the first frame update
    void Start()
    {
        Change();
        test1();
        TestGameBeat();
        LevelSystem levelSystem = new LevelSystem();
        EnemyLevel.text = "Level : " + levelSystem.GetLevelNumber();
    }

    void Change()
    {
        LevelSystem levelSystem = new LevelSystem();
        //Gets a random number with in 0 to the Srpite array Length
        rand = Random.Range(0, 9);

        //Displays the sprite that was selected by random
        GetComponent<SpriteRenderer>().sprite = Spawner_Pic[rand];
        //Displays the name that is accesed with the sprite
        EnemyName.text = " Name : " + Name[rand];

        if (levelSystem.Level >= 5)
        {
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[10];
            EnemyName.text = " Name : " + Name[11];

            EnemyLevel.text = "Level : " + (levelSystem.Level + 1);


            //EnemyLevel.text = "Level : "+1+ levelSystem.GetLevelNumber();
            Debug.Log("TEST FOR FINAL BOSS");
        }
    }

    public bool testtest = true;

    public void test1()
    {
        if(testtest == true)
        {
            Debug.Log("THSIANFJNGDJSKGDKSJHGKJDS");
        }
    }
}