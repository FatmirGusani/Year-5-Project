using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetail : MonoBehaviour
{
    public Text EnemyName;
    public Text EnemyLevel;

    private void Awake()
    {
        EnemyName = transform.Find("EnemyName").GetComponent<Text>();
        EnemyLevel = transform.Find("EnemyLevel").GetComponent<Text>();
    }

    private void SetEnnmyLevelNumber(int LevelNumber)
    {
        EnemyLevel.text = "Level : " + Random.Range(1,7);
    }


    private void SetEnemyName (int LevelNumber)
    {
        EnemyName.text = "Name : Tom";
    }

}
