using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleMenu currentMenu;


    [Header("Selection")]
    public GameObject SelectionMenu;
    public Text Fight;


    [Header("Move_Panel")]
    public GameObject MoveMenu;
    public GameObject MoveInfo;
    public Text Power;
    public Text MoveType;
    public Text Attack_1;
    public Text Attack_2;
    public Text Attack_3;
    public Text Attack_4;

    [Header("Mise")]
    public int currentSelection;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        switch(m) {


            case BattleMenu.Fight:

                SelectionMenu.gameObject.SetActive(true);
                MoveMenu.gameObject.SetActive(false);
                MoveInfo.gameObject.SetActive(false);

                break;


        }
            

    }


}

public enum BattleMenu
{
    Fight
}

