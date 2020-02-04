using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class LevelSystem : MonoBehaviour
{

    /*
    private static LevelSystem instance = null;
    public static LevelSystem SharedInstance { 
    
        get
        {
            if (instance == null) {
                instance = new LevelSystem();
            }
            return instance;
        }
        public int damnExp;

    */






    private MainMenu mainMenu;
    private MyHealthSystem myHealthSystem;
    private DisplayLevel displayLevel;

    // Start is called before the first frame update
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

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
        KeepLevel = 3;
    }

    void Start()
    {

        //myHealthSystem = gameObject.AddComponent<MyHealthSystem>();

        Experience = myHealthSystem.Exp;

        //Debug.Log("Alpha is set to : " + Experience);
    }


    /*
    public void passValue()
    {
        //Debug.Log("GETTING VALUE");

        KeepExp = myHealthSystem.add(Experience);

        Debug.Log("GETTING VALUE" + KeepExp);
    }
    */



    public void AddExperience(int amount)
    {
        //int testamount = myHealthSystem.add(amount);

        //passValue();

        Debug.Log("got the  vlaue" + amount);

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

    public void TestExperience(int amount)
    {
        //int testamount = myHealthSystem.add(amount);

        //passValue();

        Debug.Log("got the  vlaue" + amount);

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
        return KeepLevel;
    }

    public float GetExperienceNormalized()
    {
        return (float)Experience / ExperienceNextLevel;
    }

    public string ReturnExpText()
    {
        return KeepExp + "/" + ExperienceNextLevel;
    }

    private void Update()
    {
        Debug.Log("Alpha is set to : " + Experience);
    }


    /*

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


