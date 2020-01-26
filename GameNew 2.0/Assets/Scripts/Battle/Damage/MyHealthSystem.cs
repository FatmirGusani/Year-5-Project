using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This is a test//


public class MyHealthSystem : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private LevelSystem levelSystem;
    private DisplayLevel displayLevel;

    public int healthAmount;
    private int healthAmountMax;
    private bool isDeath;

    public MyHealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    //This function damages the enemy's health 
    public void Damage(int amount)
    {
        //levelSystem.AddExperience(30);
        //if the enemy's health is less then or equal to 0.
        healthAmount -= amount;
        if (healthAmount <= 0)
        {
            Debug.Log("Before");
            //isDeath = true;

            levelSystem.AddExperience(30);

            Debug.Log("After");

            healthAmount = 0;
            Debug.Log("YOU LOSE");

            SceneManager.LoadScene("GameOver");
        }

        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);

            //Debug.Log("Testing");
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


}
