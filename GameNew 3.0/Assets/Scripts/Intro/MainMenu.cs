using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private DisplayLevel displayLevel;
    private LevelSystem levelSystem;
    public Text newText;

    public bool checkfunction = false;

    void Update()
    {

    }

    public void Check()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level == 2 || levelSystem.Level == 9)
            newText.text = "New Attack unlocked";
        else
            newText.text = "";
    }


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


    public void Main_Menu()
    {
        SceneManager.LoadScene("SampleScene");
        checkfunction = true;

        /*
        LevelSystem levelSystem = new LevelSystem();
        Debug.Log("before new level" + levelSystem.Level);
        Debug.Log("before new experience" + levelSystem.Experience);
        levelSystem.Level = 1;
        levelSystem.Experience = 0;
        Debug.Log("TEst new level" + levelSystem.Level);
        Debug.Log("TEst new experience" + levelSystem.Experience);
        */


    }

    public void QuitGame ()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

}

