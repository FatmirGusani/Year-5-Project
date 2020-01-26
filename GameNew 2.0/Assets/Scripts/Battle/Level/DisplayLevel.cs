using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DisplayLevel : MonoBehaviour
{
    // public Text MyHPText;
    public Text ExpText;
    private Text LevelText;
    private Image ExpBar;

    private MainMenu mainMenu;
    private LevelSystem levelSystem;
    private HealthBar healthBar;
    private MyHealthSystem MyhealthSystem;
    //private MyHealthSystem myHealthSystem;



    private void Awake()
    {
        ExpText = transform.Find("ExpText").GetComponent<Text>();
        LevelText = transform.Find("Level").GetComponent<Text>();
        ExpBar = transform.Find("ExpBar").GetComponent<Image>();
    }


    private void SetLevelNumber(int LevelNumber)
    {
        LevelText.text = "Level : " + (LevelNumber);
    }

    /*
    public void EXP()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "GameOver")
        {
            // Do something...
            Debug.Log("Tesing EXP SENCE");

            //if (MyhealthSystem.healthAmount <= 0)
            //{
            levelSystem.AddExperience(Random.Range(10, 30));
            MyExpTextChange();
            //}
        }
    }
    */

    public void AddExpButton()
    {
        //if (MyhealthSystem.isDeath == true)
        //{
            levelSystem.AddExperience(Random.Range(10, 30));
            MyExpTextChange();
        //}
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
