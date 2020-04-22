using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelStats : MonoBehaviour
{
    private HeroLevelStats heroLevelStats;

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

    public void FanirEnemyStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            EnemyHealthIncreaseLevel += heroLevelStats.HealthIncreaseLevel / 2;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += heroLevelStats.AttackIncreaseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }

    public void LagoonEnemyStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            EnemyHealthIncreaseLevel += heroLevelStats.HealthIncreaseLevel / 2;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += heroLevelStats.AttackIncreaseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }

    public void PanbooEnemyStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level >= 15)
        {
            EnemyHealthIncreaseLevel += heroLevelStats.HealthIncreaseLevel / 2;
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += heroLevelStats.AttackIncreaseLevel / 2;
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else if (levelSystem.Level % 2 == 0)
        {
            EnemyHealthIncreaseLevel += Random.Range(5, 15);
            EnemyKeepHealthState = EnemyHealthIncreaseLevel;
            EnemyAttackIncreaseLevel += Random.Range(2, 5);
            EnemyKeepAttackState = EnemyAttackIncreaseLevel;
        }
        else
        {
            EnemyHealthIncreaseLevel = EnemyKeepHealthState;
            EnemyAttackIncreaseLevel = EnemyKeepAttackState;
        }
    }
}
