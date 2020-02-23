using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lagoon : MonoBehaviour
{

    private LevelSystem levelSystem;
    private Lagoon_EneHealth lagoonEnemyHealth;
    private Lagoon_Health lagoonHealth;

    public int[] health = { 0, 5, 50, 15, 20 };

    private int att;
    private string type;
    private int def;
    public int sendhealth;

    public void test()
    {
        LevelSystem levelSystem = new LevelSystem();
        int number = levelSystem.GetLevelNumber();
        /*
        if(number >= 2)
        {
            Debug.Log("GOT TO TESTASDASFHAJBJAD");
            sendhealth =  health[2];
        }
        */
       
    }














    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    */
}
