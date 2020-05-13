using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanirSpawner : MonoBehaviour
{

    public Sprite[] Spawner_Pic;

    //array of names
    private string[] Namelist = { "Fanir", "Super Fanir", "lagoon", "Super Lagoon"};

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        FanirSpawn();
    }

    void FanirSpawn()
    {
        //checks if player beat game with fanir//
        if (ButtonNewHero.FanirBossBeat)
        {
            //is yes, then spawn super fanir
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[1];
            Name.text = " Name : " + Namelist[1];
        }
        else
        {
            //if not then spawn normal fanir
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[0];
            Name.text = " Name : " + Namelist[0];
        }
    }
}