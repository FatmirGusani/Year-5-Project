using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{

    //[SerializeField] private DisplayLevel displayLevel;
    
    public DisplayLevel displayLevel;
    public LevelSystem levelSystem;
    public MyHealthSystem myHealthSystem;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        //myHealthSystem = new MyHealthSystem(37);
        displayLevel.SetLevelSystem(levelSystem);
    }
}
