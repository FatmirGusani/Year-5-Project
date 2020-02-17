using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lagoon_EneHealth : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private int healthAmount;
    private int healthAmountMax;

    public Lagoon_EneHealth(int healthAmount)
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
            Debug.Log("YOU WON");
            SceneManager.LoadScene("LagoonGameWon");
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }

        if (healthAmount == 0)
        {
            LevelSystem levelSystem = new LevelSystem();
            levelSystem.AddExperience(100);
            levelSystem.ReturnExpText();
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
    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
    public string emeHPTextReturn()
    {
        return healthAmount + "/" + healthAmountMax;
    }
}
