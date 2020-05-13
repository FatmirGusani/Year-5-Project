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

    //Fanir stats boost
    public void FanirStatesLevel()
    {
        //Every 3 level get more attack boost//
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 3 == 0)
        {
            AttackIncreaseLevel += 7;
            KeepAttackState = AttackIncreaseLevel;
        }
        //every 2 level gets defence and health boost//
        if(levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += Random.Range(3, 8);
            KeepHealthState = HealthIncreaseLevel;
            DefenceIncreaseLevel += Random.Range(3, 8);
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost//
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }

    //lagoon stats boost
    public void LagoonStatesLevel()
    {
        //Every 3 level get more attack boost//
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 3 == 0)
        {
            AttackIncreaseLevel += Random.Range(3, 8);
            KeepAttackState = AttackIncreaseLevel;
        }
        //every 2 level gets defence and health boost//
        if (levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += 10;
            KeepHealthState = HealthIncreaseLevel;
            DefenceIncreaseLevel += Random.Range(3, 8);
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost//
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }

    //panboo stats boost
    public void PanbooStatesLevel()
    {
        //Every 3 level get more attack boost//
        LevelSystem levelSystem = new LevelSystem();
        if (levelSystem.Level % 3 == 0)
        {
            AttackIncreaseLevel += Random.Range(3, 8);
            KeepAttackState = AttackIncreaseLevel;
        }
        //every 2 level gets defence and health boost//
        if (levelSystem.Level % 2 == 0)
        {
            HealthIncreaseLevel += Random.Range(3, 8);
            KeepHealthState = HealthIncreaseLevel;
            DefenceIncreaseLevel += 10;
            KeepDefenceState = DefenceIncreaseLevel;
        }
        else
        {
            //otherwise no stats boost//
            AttackIncreaseLevel = KeepAttackState;
            HealthIncreaseLevel = KeepHealthState;
            DefenceIncreaseLevel = KeepDefenceState;
        }
    }
}
