using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This is a test//


public class MyHealthSystem : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    //private LevelSystem levelSystem;
    //private DisplayLevel displayLevel;

    private int healthAmount;
    private int healthAmountMax;

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
            //levelSystem.AddExperience(30);
            //Load the game won scene.
            healthAmount = 0;
            //levelSystem.AddExperience(30);
            Debug.Log("YOU LOSE");
            //displayLevel.lost();
            SceneManager.LoadScene("GameOver");
            //levelSystem.AddExperience(30);

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
}
