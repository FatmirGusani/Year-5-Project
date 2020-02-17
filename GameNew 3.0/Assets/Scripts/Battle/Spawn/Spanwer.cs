using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spanwer : MonoBehaviour
{
    private int rand;
    public Sprite[] Spawner_Pic;

    string[] Name = new string[] { "name1", "name2", "name3", "name4", "name5" };


    //string[] names = new string[] { "Matt", "Joanne", "Robert" };

    public Text EnemyName;
    public Text EnemyLevel;
    //private DisplayLevel displayLevel;

    private void Awake()
    {
        EnemyName = transform.Find("EnemyName").GetComponent<Text>();
        EnemyLevel = transform.Find("EnemyLevel").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Change();
        EnemyLevel.text = "Level : " + Random.Range(1,100);
        //string v = EnemyName.text = "Name : Tom" + Name[i];
        Debug.Log(Name);
        //Test();
    }

    void Test()
    {

        /*
        if(Spawner_Pic[1])
        {
            name = "Test 1";
            Debug.Log("test 1");
        }
        if (Spawner_Pic[2])
        {
            name = "Test 2";
            Debug.Log("test 2");
        }
        if (Spawner_Pic[3])
        {
            name = "Test 3";
            Debug.Log("test 3");
        }
        if (Spawner_Pic[4])
        {
            name = "Test 4";
            Debug.Log("test 4");
        }
        if (Spawner_Pic[5])
        {
            name = "Test 5";
            Debug.Log("test 5");
        }
        if (Spawner_Pic[6])
        {
            name = "Test 6";
            Debug.Log("test 6");
        }
        if (Spawner_Pic[7])
        {
            name = "Test 7";
            Debug.Log("test 7");
        }
        if (Spawner_Pic[8])
        {
            name = "Test 8";
            Debug.Log("test 8");
        }
        if (Spawner_Pic[9])
        {
            name = "Test 19";
            Debug.Log("test 9");
        }
        */
    }

    void Change()
    {
        rand = Random.Range(0, Spawner_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Spawner_Pic[rand];
    }
}
