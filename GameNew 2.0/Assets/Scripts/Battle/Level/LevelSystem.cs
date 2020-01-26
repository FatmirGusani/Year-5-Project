using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelSystem
{

    private MainMenu mainMenu;

    // Start is called before the first frame update
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

    private MyHealthSystem MyHealthSystem;

    private int Level;
    private int Experience;
    private int ExperienceNextLevel;

    private static int KeepExp;
    private static int KeepLevel;

    public LevelSystem()
    {
        Level = KeepLevel;
        Experience = KeepExp;

        ExperienceNextLevel = 100;
        KeepExp = 0;
        KeepLevel = 20;
    }

    public void AddExperience(int amount)
    {

        Experience += amount;
        if (Experience >= ExperienceNextLevel)
        {
            Level++;
            Experience -= ExperienceNextLevel;

           

            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);
            //KeepLevel = Level;
        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);

        KeepExp = Experience;
        KeepLevel = Level;

        Debug.Log("Keep " + KeepExp);
        Debug.Log("EXP " + Experience);
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

        //return Experience + "/" + ExperienceNextLevel;
    }

    public void AddlittleEXP()
    {
        if(MyHealthSystem  == true)
        {
            Debug.Log("testsing");
            AddExperience(20);
        }
    }
    
}
