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
    public void FanirStarter()
    {
        SceneManager.LoadScene("FanirScene");
    }
    public void LagoonStarer()
    {
        SceneManager.LoadScene("LagoonScene");
    }
    public void PanbooStarter()
    {
        SceneManager.LoadScene("PanbooScene");
    }

    ////////////////////////Fanir///////////////////////////////////////
    public void Greenwing_GameWon()
    {
        SceneManager.LoadScene("FanirGameWon");
    }
    public void Greenwing_GameOver()
    {
        SceneManager.LoadScene("FanirGameOver");
    }


    ////////////////////////Lagoon///////////////////////////////////////
    public void Lagoon_GameOver()
    {
        SceneManager.LoadScene("LagoonGameOver");
    }

    public void Lagoon_GameWon()
    {
        SceneManager.LoadScene("LagoonGameWon");
    }

    ////////////////////////Panboo///////////////////////////////////////
    public void Panboo_GameOver()
    {
        SceneManager.LoadScene("PanbooGameOver");
    }

    public void Panboo_GameWon()
    {
        SceneManager.LoadScene("PanbooGameWon");
    }

    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>

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

