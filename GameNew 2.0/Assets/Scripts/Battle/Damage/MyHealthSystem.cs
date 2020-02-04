using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This is a test//

using UnityEngine.UI;


public class MyHealthSystem : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDeath;
    //private LevelSystem levelSystem;
    //private DisplayLevel displayLevel;
    private DisplayLevel displayLevel;
    public LevelSystem levelSystem;

    private int healthAmount;
    private int healthAmountMax;
    public int Exp = 30;


    void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        if (healthAmount == 0)
        {
            Debug.Log("AWAKE");
            levelSystem.AddExperience(50);
        }
    }

    private void Start()
    {
        Debug.Log("testing start value" + Exp);
        levelSystem.AddExperience(Exp);
    }

    public MyHealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }


    //This function damages the enemy's health 
    public void Damage(int amount)
    {


        //if the enemy's health is less then or equal to 0.
        healthAmount -= amount;
        if (healthAmount <= 0)
        {
            healthAmount = 0;
            Debug.Log("YOU LOSE");

            //levelSystem.AddExperience(30);

            //displayLevel.lost();
            SceneManager.LoadScene("GameOver");
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }

        if (healthAmount == 0)
        {
            //add(Exp);
            //levelSystem.AddExperience(50);
            //Testhealth();
            //displayLevel.TestAdd();
        }
    }

    //This function heals the enemy's health 
    public void Heal(int amount)
    {
        healthAmount += amount;
        if (healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null)
        {
            OnHealed(this, EventArgs.Empty);
        }
    }

    //Function returns enemy's current health 
    public float MyGetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
    public string MyHPTextReturn()
    {
        return healthAmount + "/" + healthAmountMax;
    }

    /*
    public int add(int Exp)
    {
        levelSystem.TestExperience(20);
        Debug.Log("Value Returned : " + Exp);
        //levelSystem.AddExperience(79)
        return Exp;
    }
    */
}
