using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public enum BattleStates
    {
        Fight,
        PlayerInput,
        EnemyInput,
        Lose,
        Win
    }

    private BattleStates CurrentState;


    // Start is called before the first frame update
    void Start()
    {
        CurrentState = BattleStates.Fight;     
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case (BattleStates.Fight):
            {
                    break;

            }

            case (BattleStates.PlayerInput):
            {
                break;

            }

            case (BattleStates.EnemyInput):
            {
                break;

            }

            case (BattleStates.Lose):
            {
                break;

            }

            case (BattleStates.Win):
            {
                break;

            }


        }

        
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Fight"))
        {
            if (CurrentState == BattleStates.Fight)
                CurrentState = BattleStates.PlayerInput;

            if (GUILayout.Button("Attack 1"))
            {
                if (CurrentState == BattleStates.PlayerInput)
                    CurrentState = BattleStates.EnemyInput;
            }

        }

        
    }
 
}
