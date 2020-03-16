using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{

    //[SerializeField] private DisplayLevel displayLevel;
    
    public DisplayLevel displayLevel;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
       
        displayLevel.SetLevelSystem(levelSystem);
    }
}
