using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretEnemySpawner : MonoBehaviour
{
    private int rand;

    public Sprite[] Spawner_Pic;

    private string[] Name = { "Wallabyss", "Toalow", "Penguna", "Mantitar", "Kineling", "Magmelope", "Wintora", "Dracaza", "Quackal", "Staropotamus", "Territe", "Super Fanir",
                              "Toatone", "Croros", "Crazekey", "Ramparak", "Lobsteroid", "Pandyle", "Waroda", "Chickombo", "Dradrill", "Hunteleon", "Mermantis", "Super Panboo",
                              "Crosaur", "Elanyte", "Hippopoke", "Pandoke", "Chimesel", "Whirlkey", "Boneleon", "Goldingale", "Quackal", "Drummingbird", "Frogre", "Scorpilite",
                              "Crofree", "Vultune", "Riotter" ,"Super Lagoon"};

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
        rand = Random.Range(0, 39);

        //Displays the sprite that was selected by random
        GetComponent<SpriteRenderer>().sprite = Spawner_Pic[rand];
        //Displays the name that is accesed with the sprite
        EnemyName.text = " Name : " + Name[rand];

    }
}