using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private DisplayLevel displayLevel;
    private LevelSystem levelSystem;
    private HeroLevelStats heroLevelStats;
    private EnemyLevelStats enemyLevelStats;
    public Text newText;

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
        LevelSystem.KeepLevel = 1;
        LevelSystem.KeepExp = 0;
        HeroLevelStats.KeepAttackState = 0;
        HeroLevelStats.KeepDefenceState = 0;
        HeroLevelStats.KeepHealthState = 0;
        EnemyLevelStats.EnemyKeepAttackState = 0;
        EnemyLevelStats.EnemyKeepDefenceState = 0;
        EnemyLevelStats.EnemyKeepHealthState = 0;
    }

    public void QuitGame ()
    {
        Debug.Log("Quiting");
        Application.Quit();
    }

}

