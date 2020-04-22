using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLevelStats : MonoBehaviour
{
    public int HealthIncreaseLevel = KeepHealthState;
    public static int KeepHealthState = 0;
    public int AttackIncreaseLevel = KeepAttackState;
    public static int KeepAttackState = 0;
    public int DefenceIncreaseLevel = KeepDefenceState;
    public static int KeepDefenceState = 0;

    // Start is called before the first frame update
    void Start()
    {
        FanirStatesLevel();
        LagoonStatesLevel();
        PanbooStatesLevel();
    }

    public void FanirStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += Random.Range(3, 8);
            KeepHealthState = HealthIncreaseLevel;
            AttackIncreaseLevel += 10;
            KeepAttackState = AttackIncreaseLevel;
            DefenceIncreaseLevel += Random.Range(3, 8);
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }

    public void LagoonStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += 10;
            KeepHealthState = HealthIncreaseLevel;
            AttackIncreaseLevel += Random.Range(3, 8);
            KeepAttackState = AttackIncreaseLevel;
            DefenceIncreaseLevel += Random.Range(3, 8);
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }

    public void PanbooStatesLevel()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += Random.Range(3, 8);
            KeepHealthState = HealthIncreaseLevel;
            AttackIncreaseLevel += Random.Range(3, 8);
            KeepAttackState = AttackIncreaseLevel;
            DefenceIncreaseLevel += 10;
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }


}
