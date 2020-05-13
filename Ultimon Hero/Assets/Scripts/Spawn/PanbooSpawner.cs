using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanbooSpawner : MonoBehaviour
{
    public Sprite[] Spawner_Pic;

    //array of names
    private string[] Namelist = { "Panboo", "Super Panboo" };

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        PanbooSpawn();
    }

    void PanbooSpawn()
    {
        //checks if player beat game with panboo//
        if (ButtonNewHero.FanirBossBeat)
        {
            //is yes, then spawn super panboo
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[1];
            Name.text = " Name : " + Namelist[1];
        }
        else
        {
            //if not then spawn normal panboo
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[0];
            Name.text = " Name : " + Namelist[0];
        }
    }
}
