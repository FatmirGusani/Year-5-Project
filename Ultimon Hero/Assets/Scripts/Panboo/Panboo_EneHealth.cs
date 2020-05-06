using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panboo_EneHealth : MonoBehaviour
{
    //Events notofiys when the health changes.
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private int healthAmount;
    private int healthAmountMax;
    public int amountValue;


    public Panboo_EneHealth(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    //This function damages the enemy's health 
    public void Damage(int amount)
    {
        LevelSystem levelSystem = new LevelSystem();
        //if the enemy's health is less then or equal to 0.
        healthAmount -= amount;
        amountValue = amount;

        if (levelSystem.Level >= 2 && healthAmount <= 0)
        {
            ButtonNewHero newHero = new ButtonNewHero();
            healthAmount = 0;
            SceneManager.LoadScene("GameBeat");
            ButtonNewHero.PanbooBossBeat = true;
        }
        else if (healthAmount <= 0)
        {
            //Load the game won scene.
            healthAmount = 0;
            SceneManager.LoadScene("PanbooGameWon");
            //LevelSystem levelSystem = new LevelSystem();
            levelSystem.AddExperience(100);
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
    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
    public string emeHPTextReturn()
    {
        return healthAmount + "/" + healthAmountMax;
    }
}
