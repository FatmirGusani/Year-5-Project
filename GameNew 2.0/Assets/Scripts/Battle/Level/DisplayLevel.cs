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
    //private HealthBar healthBar;
    private MyHealthSystem MyhealthSystem;

    private void Awake()
    {

        LevelText = transform.Find("Level").GetComponent<Text>();
        ExpBar = transform.Find("ExpBar").GetComponent<Image>();
        //transform.Find("AddExp").GetComponent<Button>();

        //SetExperienceBarSize(.8f);
        //SetLevelNumber(50);
        //SetExp(43);
    }

    private void SetExperienceBarSize(float ExperienceNormalized)
    {
        ExpBar.fillAmount = ExperienceNormalized;
    }

    private void SetLevelNumber (int LevelNumber)
    {
        LevelText.text = "Level : " + (LevelNumber);
    }

    public void AddExpButton()
    {
        levelSystem.AddExperience(30);
        MyExpTextChange();
    }

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










}
