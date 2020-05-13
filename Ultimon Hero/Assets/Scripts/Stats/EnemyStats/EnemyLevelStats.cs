using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelStats : MonoBehaviour
{
    private int EnemyHealthIncreaseLevel = EnemyKeepHealthState;
    public static int EnemyKeepHealthState = 0;
    private int EnemyAttackIncreaseLevel = EnemyKeepAttackState;
    public static int EnemyKeepAttackState = 0;
    private int EnemyDefenceIncseLevel = EnemyKeepDefenceState;
    public static int EnemyKeepDefenceState = 0;


    void Start()
    {
        FanirEnemyStatesLevel();
        LagoonEnemyStatesLevel();
        PanbooEnemyStatesLevel();
    }

    //Fanir enemy stat boost
    public void FanirEnemyStatesLevel()
    {
        //super fanir stats boost
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 2 )
        {
            //gets the health and attack and appliys it to itown//
            HeroLevelStats heroLevelStats = new HeroLevelStats();
            EnemyHealthIncreaseLevel = heroLevelStats.HealthIncreaseLevel;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel = heroLevelStats.AttackIncreaseLevel * 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            //otherwise normal stats boost//
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }

    //lagoon enemy stat boost
    public void LagoonEnemyStatesLevel()
    {
        //super lagoon stats boost
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            HeroLevelStats heroLevelStats = new HeroLevelStats();
            EnemyHealthIncreaseLevel += heroLevelStats.HealthIncreaseLevel / 2;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += heroLevelStats.AttackIncreaseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            //otherwise normal stats boost//
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }

    //panboo enemy stat boost
    public void PanbooEnemyStatesLevel()
    {
        //super panboo stats boost
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            HeroLevelStats heroLevelStats = new HeroLevelStats();
            EnemyHealthIncreaseLevel += heroLevelStats.HealthIncreaseLevel / 2;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += heroLevelStats.AttackIncreaseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            //otherwise normal stats boost//
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }
}
