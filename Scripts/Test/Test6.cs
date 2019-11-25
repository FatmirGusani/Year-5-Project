using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey;

public class Test6 : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private int healthAmount;
    private int healthAmountMax;

    public Test6(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
        //healthAmountMax = healthAmount
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;
        if(healthAmount < 0)
        {
            healthAmount = 0;
        }
        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);
    }

    public void heal(int amount)
    {
        healthAmount += amount;
        if(healthAmount > healthAmountMax)
        {
            healthAmount = healthAmountMax;
        }
        if (OnHealed != null) OnHealed(this, EventArgs.Empty);
    }

    public float GetHealthNormalized()
    {
        return healthAmount / healthAmountMax;
    }

}
