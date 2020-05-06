using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretSpawner : MonoBehaviour
{
    public Sprite[] Spawner_Pic;

    private string[] Namelist = { "Ray" };

    public Text Name;

    // Start is called before the first frame update
    void Start()
    {
        RaySpawn();
    }

    void RaySpawn()
    {
        GetComponent<SpriteRenderer>().sprite = Spawner_Pic[0];
        Name.text = " Name : " + Namelist[0];
    }
}