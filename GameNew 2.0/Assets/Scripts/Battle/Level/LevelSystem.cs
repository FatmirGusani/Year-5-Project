using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class LevelSystem : MonoBehaviour
{
    private MainMenu mainMenu;
    private MyHealthSystem myHealthSystem;
    private DisplayLevel displayLevel;

    // Start is called before the first frame update
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

    /*
    private void MyHealthSystem_OnDeath(object sender, System.EventArgs e)
    {
        Debug.Log("GOT HERE");
        //myHealthSystem.MyGetHealthNormalized();
        if(myHealthSystem.MyGetHealthNormalized() == 0)
        {
            AddExperience(20);
        }
    }
    */

    private int Level;
    private int Experience;
    private int ExperienceNextLevel;

    private static int KeepExp;
    private static int KeepLevel;

    public LevelSystem()
    {
        Level = KeepLevel;
        Experience = KeepExp;
        //Experience = 2;

        ExperienceNextLevel = 100;
        KeepExp = 0;
        KeepLevel = 20;
    }

    public void Function()
    {
        Debug.Log("TESTING FUNCTION : " + KeepExp);
        //Experience = myHealthSystem.GetEstimatedDistance(KeepExp);
        //Debug.Log("TESTING FUNCTION : " + KeepExp);
    }

    public void AddExperience(int amount)
    {
        //myHealthSystem.GetEstimatedDistance(Experience);
        Debug.Log("got the  vlaue" + amount);

        //Experience += result;

        if (Experience >= ExperienceNextLevel)
        {
            Level++;
            Experience -= ExperienceNextLevel;
            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);
            //KeepLevel = Level;

            Debug.Log("EXP HAS RUN");
        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);

        //getreturn(RV);

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

    /*
    private void MyloseEXPSend(object sender, System.EventArgs e)
    {
        MySetHealth(myHealthSystem.MyLoseEXP());
    }
    */

    /*
public void passValue()
{
    Debug.Log("GETTING VALUE");
    //Experience = myHealthSystem.returningvalue(test);

    //AddExperience(test);
    //Debug.Log(test);

    //Experience;
    int zero = 0;

    int zeroresult = myHealthSystem(zero);

    //de
    //sreturningvalue

    //int result = myHealthSystem.SquareANumber(5);
    //result = myHealthSystem.SquareANumber(Experience);

    //myHealthSystem.SquareANumber(Experience);
    Experience = myHealthSystem.GetEstimatedDistance();



    Debug.Log("GETTING VALUE122222222222");
}



    public void GettingReturnvalue()
    {
       if(myHealthSystem.ReturningHealth() == 0)
        {
            Debug.Log("Testing GettingReturnValue");
            Experience = 20;
            Debug.Log("Testing GettingReturn" + Experience);
        }
    }

    


     public void Addexpfromhealth()
    {

    }

    {

    public void Getter(int Experience)
    {
        myHealthSystem.Setter(Experience);

        Debug.Log("Expsdgsh" + Experience);
        KeepExp = Experience;
    }

    */
}


