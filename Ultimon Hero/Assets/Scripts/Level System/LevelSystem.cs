using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

    public int Level = KeepLevel;
    public int Experience = KeepExp;
    private int ExperienceNextLevel = 100;

    public static int KeepExp = 0;
    public static int KeepLevel = 1;

    //this function adds the experince to the hero.
    public void AddExperience(int amount)
    {
        //depends on what the outcome out the battle is, differnt amount value//
        //adds the amount to experience//
        Experience += amount;

        //if the experince is greater then max experience
        if (Experience >= ExperienceNextLevel)
        {
            //add level//
            Level++;
            //subtract max experience from current experince//
            Experience -= ExperienceNextLevel;

            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);
            KeepLevel = Level;
        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);
        KeepExp = Experience;
    }

    //return the level
    public int GetLevelNumber()
    {
            return Level;
    }

    //Gets the current experince
    public float GetExperienceNormalized()
    {
        return (float)Experience / ExperienceNextLevel;
    }

    //return experince text to display//
    public string ReturnExpText()
    {
        return KeepExp + "/" + ExperienceNextLevel;
    }
}



