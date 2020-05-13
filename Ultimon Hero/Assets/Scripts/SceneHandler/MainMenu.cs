using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text newText;

    //&& LagoonBossBeat && PanbooBossBeat
    private void Update()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level == 2 || levelSystem.Level == 9)
        {
            newText.text = "New Attack Unlocked";
        }
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
    public void SecretHero()
    {
        SceneManager.LoadScene("SecretHeroScenes");
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

    ////////////////////////Secret Hero///////////////////////////////////////
    public void SecretHero_GameOver()
    {
        SceneManager.LoadScene("SecretHeroLose");
    }

    public void SecretHero_GameWon()
    {
        SceneManager.LoadScene("SecretHeroWin");
    }

    //Reset Everything once main menu button clicked.
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

