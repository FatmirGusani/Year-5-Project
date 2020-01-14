using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelSystem 
{

    // Start is called before the first frame update

    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;


    private int Level;
    private int Experience;
    private int ExperienceNextLevel;

    public LevelSystem()
    {
        Level = 20;
        Experience = 0;
        ExperienceNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        Experience += amount;
        if(Experience >= ExperienceNextLevel)
        {
            Level++;
            Experience -= ExperienceNextLevel;
            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);
        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);

        
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
        return Experience + "/" + ExperienceNextLevel;
    }
}
