using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLevel : MonoBehaviour
{
   // public Text MyHPText;
    private Text ExpText;
    private Text LevelText;
    private Image ExpBar;
    private Button Attack5;
    private Button Attack6;

    private LevelSystem levelSystem;



    private void Awake()
    {
        ExpText = transform.Find("ExpText").GetComponent<Text>();
        LevelText = transform.Find("Level").GetComponent<Text>();
        ExpBar = transform.Find("ExpBar").GetComponent<Image>();
        Attack5 = transform.Find("ExpBar").GetComponent<Button>();

        LevelSystem levelSystem = new LevelSystem();
        SetLevelSystem(levelSystem);
    }

    void Update()
    {
        MyExpTextChange();
    }

    private void SetLevelNumber (int LevelNumber)
    { 
        LevelText.text = "Level : " + LevelNumber;
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
        //MyExpTextChange();

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
