using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanirSpawner : MonoBehaviour
{

    public Sprite[] Spawner_Pic;

    private string[] Namelist = { "Fanir", "Super Fanir", "lagoon", "Super Lagoon"};

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        FanirSpawn();
    }

    void FanirSpawn()
    {
        if (ButtonNewHero.FanirBossBeat)
        {
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[1];
            Name.text = " Name : " + Namelist[1];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Spawner_Pic[0];
            Name.text = " Name : " + Namelist[0];
        }
    }
}