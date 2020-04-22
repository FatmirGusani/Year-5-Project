using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lagoon_Health : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDeath;
    //private LevelSystem levelSystem;
    //private DisplayLevel displayLevel;
    private DisplayLevel displayLevel;
    private LevelSystem levelSystem;

    public int healthAmount;
    public int amountValue;
    private int healthAmountMax;

    public Lagoon_Health(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    //This function damages the enemy's health 
    public void Damage(int amount)
    {
        //if the enemy's health is less then or equal to 0.
        healthAmount -= amount;
        amountValue = amount;

        if (healthAmount <= 0)
        {
            //Load the game won scene.
            healthAmount = 0;

            SceneManager.LoadScene("LagoonGameOver");
            LevelSystem levelSystem = new LevelSystem();
            levelSystem.AddExperience(25);
            levelSystem.ReturnExpText();
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
        amountValue = amount; 

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
