using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private DisplayLevel displayLevel;
    private LevelSystem levelSystem;


    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    ////////////////////////Starters///////////////////////////////////////
    public void CharizardStarter()
    {
        SceneManager.LoadScene("CharizardScene");
    }
    public void BlastoiseStarer()
    {
        SceneManager.LoadScene("BlastoiseScene");
    }
    public void VenusaurStarter()
    {
        SceneManager.LoadScene("VenusaurScene");
    }

    ////////////////////////Char///////////////////////////////////////
    public void charNextBattle()
    {
        SceneManager.LoadScene("NextbattleTest");
    }
    public void charPlayAgain()
    {
        //levelSystem.AddExperience(UnityEngine.Random.Range(10, 30));
        //displayLevel.AddExpButton();
        //levelSystem.AddExperience(20);
        SceneManager.LoadScene("CharizardScene");
    }

    //public void AddEXPS()
    //{
    //   levelSystem.AddExperience(Random.Range(10, 30));
    //    displaylevel.MyExpTextChange();
    //}

    ////////////////////////Blast///////////////////////////////////////
    public void blastPlayAgain()
    {
        SceneManager.LoadScene("BlastoiseScene");
    }

    public void blastNextBattle()
    {
        SceneManager.LoadScene("BastNextBattle");
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame ()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

}

