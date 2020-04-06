using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private MainMenu mainMenu;
    private MyHealthSystem myHealthSystem;
    private DisplayLevel displayLevel;

    // Start is called before the first frame update
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

    public int Level = KeepLevel;
    public int Experience = KeepExp;
    private int ExperienceNextLevel = 100;

    private static int KeepExp = 0;
    private static int KeepLevel = 1;

    

    public void AddExperience(int amount)
    {
        Experience += amount;

        if (Experience >= ExperienceNextLevel)
        {
            Level++;
            Experience -= ExperienceNextLevel;
            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);
            //KeepLevel = Level;
            KeepLevel = Level;
        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);

        KeepExp = Experience;
    }

    public int GetLevelNumber()
    {
            return Level;
    }

    public float GetExperienceNormalized()
    {
        return (float)Experience / ExperienceNextLevel;
    }

    public string ReturnExpText()
    {
        return KeepExp + "/" + ExperienceNextLevel;
    }

    public void test()
    {
        if (mainMenu.checkfunction == true)
        {
           // Debug.Log("come here");
            KeepLevel = 0;
            KeepExp = 0;
        }
    }
}



