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
    private LevelSystem levelSystem;

    private int healthAmount;
    private int healthAmountMax;
    private int Exp;


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
            //Load the game won scene.
            healthAmount = 0;
            //Settertest(20);

            Testhealth();

            //levelSystem.AddExperience(30);

            Debug.Log("YOU LOSE");

            //displayLevel.lost();
            SceneManager.LoadScene("GameOver");
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
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

    
    public int Settertest(int Exp)
    {
        Debug.Log("THIS IS SETTERTEST");

        Debug.Log("SetterTEst Value" + Exp);
        //return Exp;

        //levelSystem.GetExperienceNormalized();

        return Exp;
    }

    public void Testhealth()
    {
        if (healthAmount == 0)
        {
            displayLevel.AddExpButton();
        }
    }
    
}
