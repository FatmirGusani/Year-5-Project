using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    private int healthAmount;
    private int healthAmountMax;

    public MyHealthSystem(int healthAmount)
    {
        healthAmountMax = healthAmount;
        this.healthAmount = healthAmount;
    }

    public void Damage(int amount)
    {
        healthAmount -= amount;
        if (healthAmount < 0)
        {
            healthAmount = 0;
            Debug.Log("YOU LOSE");
        }
        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }
    }

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

    public float MyGetHealthNormalized()
    {
        return (float)healthAmount / healthAmountMax;

    }

    internal void Damage(Action random_Damage)
    {
        throw new NotImplementedException();
    }

    internal void Damage(object p)
    {
        throw new NotImplementedException();
    }
}
