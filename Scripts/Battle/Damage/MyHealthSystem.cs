﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This is a test//


public class MyHealthSystem : MonoBehaviour
{
    //creates 2 event handlers, damage and heal
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    //crated a varable for the health and maxhealth.
    private int healthAmount;
    private int healthAmountMax;

    public MyHealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    //This function damages our hero's health 
    public void Damage(int amount)
    {
        healthAmount -= amount;

        if (healthAmount <= 0)
        {
            //if our health is less then or equal to 0. load the "gameover scene"
            healthAmount = 0;
            Debug.Log("YOU LOSE");
            SceneManager.LoadScene("GameOver");
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }
    }

    //This function heals our hero's health 
    public void Heal(int amount)
    {
        healthAmount += amount;
        if (healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null)
            OnHealed(this, EventArgs.Empty);
    }

    //Function returns our current health 
    public float MyGetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;
    }
}
