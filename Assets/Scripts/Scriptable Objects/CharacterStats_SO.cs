using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewStats", menuName ="Character/Stats" , order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickUp weapon { get; private set; }
    public ItemPickUp headArmour { get; private set; }
    public ItemPickUp chestArmour { get; private set; }
    public ItemPickUp handArmour { get; private set; }
    public ItemPickUp legArmour { get; private set; }
    public ItemPickUp feetArmour { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }


    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0f;
    public float currentResistance = 0f;

    public float currentEncumberance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;

    public void ApplyHealth(int healthAmount)
    {
        if((currentHealth + healthAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void ApplyMana(int manaAmount)
    {
        if((currentMana + manaAmount) >maxMana)
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += manaAmount;
        }
    }

    public void GiveWealth(int wealthAmount)
    {
        if ((currentWealth + wealthAmount) > maxWealth)
        {
            currentWealth = maxWealth;
        }
        else
        {
            currentWealth += wealthAmount;
        }
    }

}
