using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene("CharizardScene");
    }

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

