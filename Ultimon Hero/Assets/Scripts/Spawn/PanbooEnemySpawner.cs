using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanbooEnemySpawner: MonoBehaviour
{
    private int rand;

    public Sprite[] Spawner_Pic;

    //array of names
    private string[] Name = { "Toatone", "Croros", "Crazekey", "Ramparak", "Lobsteroid", "Pandyle", "Waroda", "Chickombo", "Dradrill", "Hunteleon", "Mermantis", "Super Panboo" };

    public Text EnemyName;
    public Text EnemyLevel;

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
        }
    }
}