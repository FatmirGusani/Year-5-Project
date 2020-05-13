using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LagoonSpawner : MonoBehaviour
{
    public Sprite[] Spawner_Pic;

    //array of names
    private string[] Namelist = { "Lagoon", "Super Lagoon"};

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        LagoonSpawn();
    }

    void LagoonSpawn()
    {
        //checks if player beat game with lag0on//
        if (ButtonNewHero.FanirBossBeat)
        {
            //is yes, then spawn super lagoon
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[1];
            Name.text = " Name : " + Namelist[1];
        }
        else
        {
            //if not then spawn normal lagoon
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[0];
            Name.text = " Name : " + Namelist[0];
        }
    }
}
