using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLevel : MonoBehaviour
{
   // public Text MyHPText;
    public Text ExpText;
    private Text LevelText;
    private Image ExpBar;
    private LevelSystem levelSystem;
    private int KeepExp = 30;

    private MainMenu mainMenu;
    //private HealthBar healthBar;
    private MyHealthSystem MyhealthSystem;



    private void Awake()
    {
        ExpText = transform.Find("ExpText").GetComponent<Text>();
        LevelText = transform.Find("Level").GetComponent<Text>();
        ExpBar = transform.Find("ExpBar").GetComponent<Image>();
        //levelSystem = GameObject.FindObjectOfType<LevelSystem>();
    }


    private void SetLevelNumber (int LevelNumber)
    {
        LevelText.text = "Level : " + (LevelNumber);
    }

    public void TestAdd()
    {
        levelSystem.AddExperience(40);
        MyExpTextChange();
    }

    public void AddExpButton()
    {
        //int Experience = 20;

        Debug.Log("TESTING FUNCTION : " + KeepExp);
        //Experience = MyhealthSystem.GetEstimatedDistance(KeepExp);
        //Debug.Log("TESTING FUNCTION : " + KeepExp);
        /////////////////////////////////////////////////////////
        levelSystem.AddExperience(20);
        MyExpTextChange();
    }

    /*
    public void test()
    {
        int gottonexp = 50;
        Debug.Log("dskhgwkgksGH;SDHG");
        int result = MyhealthSystem.GetEstimatedDistance(gottonexp);
        levelSystem.AddExperience(gottonexp);
    }
    */

    public void MyExpTextChange()
    {
        ExpText.text = levelSystem.ReturnExpText(); 
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        //Set the LevelSystem object//
        this.levelSystem = levelSystem;

        //Update the starting value
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        //SetKeepExpBarSize(levelSystem.GetKeepExp());

        //sMyExpTextChange();

        //Surbscribe to the change events
        levelSystem.OnExperienceChange += LevelSystem_OnExperienceChange;
        levelSystem.OnLevelChange += LevelSystem_OnLevelChange;
    }

    private void LevelSystem_OnLevelChange(object sender, System.EventArgs e)
    {
        //Level change, update text//
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExperienceChange(object sender, System.EventArgs e)
    {
        //Experience change, update Bar Size//
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }

    private void SetExperienceBarSize(float ExperienceNormalized)
    {
        ExpBar.fillAmount = ExperienceNormalized;
    }
}
