using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spanwer : MonoBehaviour
{
    private int rand;

    public Sprite[] Spawner_Pic;

    private string[] Name = { "Crosaur", "Elanyte", "Hippopoke", "Pandoke", "Chimesel", "Whirlkey", "Boneleon", "Goldingale", "Quackal", "Drummingbird", "Frogre", "Super Lagoon"};

    public Text EnemyName;
    public Text EnemyLevel;


    private int number;

    private LevelSystem levelSystem;

    private void Awake()
    {
        EnemyName = transform.Find("EnemyName").GetComponent<Text>();
        EnemyLevel = transform.Find("EnemyLevel").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Change();
        LevelSystem levelSystem = new LevelSystem();
        EnemyLevel.text = "Level : " + levelSystem.GetLevelNumber();
    }

    void Change()
    {
        LevelSystem levelSystem = new LevelSystem();
        //Gets a random number with in 0 to the Srpite array Length
        rand = Random.Range(0,9);

        //Displays the sprite that was selected by random
        GetComponent<SpriteRenderer>().sprite = Spawner_Pic[rand];
        //Displays the name that is accesed with the sprite
        EnemyName.text = " Name : " + Name[rand];

        if(levelSystem.Level >= 10)
        {
            
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[10];
            EnemyName.text = " Name : " + Name[11];

            EnemyLevel.text = "Level : " + (levelSystem.Level+1);


            //EnemyLevel.text = "Level : "+1+ levelSystem.GetLevelNumber();
            Debug.Log("TEST FOR FINAL BOSS");
        }
    }
}