using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class TestLevel : MonoBehaviour
{
    public DisplayLevel displayLevel;
    //[SerializeField] private HealthBar healthBar;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        displayLevel.SetLevelSystem(levelSystem);        
    }
}
