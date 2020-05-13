using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    private Button Attack1;
    private Button Attack2;
    private Button Attack3;
    private Button Attack4;
    private Button Attack5;
    private Button Attack6;
    private Button Heal;

    void Awake()
    {
        //Gets the reference//
        Attack1 = GetComponent<Button>();
        Attack2 = GetComponent<Button>();
        Attack3 = GetComponent<Button>();
        Attack4 = GetComponent<Button>();
        Attack5 = GetComponent<Button>();
        Attack6 = GetComponent<Button>();
        Heal = GetComponent<Button>();
    }

    public IEnumerator ButtonAttackDelay()
    {
        //Disables all the buttons//
        Attack1 = GameObject.Find("Attack1Button").GetComponent<Button>();
        Attack1.interactable = false;

        Attack2 = GameObject.Find("Attack2Button").GetComponent<Button>();
        Attack2.interactable = false;

        Attack3 = GameObject.Find("Attack3Button").GetComponent<Button>();
        Attack3.interactable = false;

        Attack4 = GameObject.Find("Attack4Button").GetComponent<Button>();
        Attack4.interactable = false;

        Attack5 = GameObject.Find("Attack5Button").GetComponent<Button>();
        Attack5.interactable = false;

        Attack6 = GameObject.Find("Attack6Button").GetComponent<Button>();
        Attack6.interactable = false;

        Heal = GameObject.Find("HealButton").GetComponent<Button>();
        Heal.interactable = false;

        //Wait 2 second//
        yield return new WaitForSeconds(2f);

        //Enable all button//
        Attack1 = GameObject.Find("Attack1Button").GetComponent<Button>();
        Attack1.interactable = true;

        Attack2 = GameObject.Find("Attack2Button").GetComponent<Button>();
        Attack2.interactable = true;

        Attack3 = GameObject.Find("Attack3Button").GetComponent<Button>();
        Attack3.interactable = true;

        Attack4 = GameObject.Find("Attack4Button").GetComponent<Button>();
        Attack4.interactable = true;

        Attack5 = GameObject.Find("Attack5Button").GetComponent<Button>();
        Attack5.interactable = true;

        Attack6 = GameObject.Find("Attack6Button").GetComponent<Button>();
        Attack6.interactable = true;

        Heal = GameObject.Find("HealButton").GetComponent<Button>();
        Heal.interactable = true;
    }
}
