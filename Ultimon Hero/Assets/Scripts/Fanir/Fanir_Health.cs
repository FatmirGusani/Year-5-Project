using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fanir_Health : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
   
    public int healthAmount;
    private int healthAmountMax;
    public int amountValue;

    public Fanir_Health(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    //This function damages the hero's health 
    public void Damage(int amount)
    {
        //if the heros's health is less than or equal to 0.
        healthAmount -= amount;
        amountValue = amount;
        if (healthAmount <= 0)
        {
            //Load the game won scene.
            healthAmount = 0;
            SceneManager.LoadScene("FanirGameOver");

            LevelSystem levelSystem = new LevelSystem();

            levelSystem.AddExperience(25);
            levelSystem.ReturnExpText();
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        } 
    }

    //This function heals the hero's health 
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

    //Function returns hero's current health 
    public float MyGetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }

    //returns the current health out of max health
    public string MyHPTextReturn()
    {
        return healthAmount + "/" + healthAmountMax;
    }
}
