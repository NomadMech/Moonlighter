using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewStats", menuName ="Character/Stats" , order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    [System.Serializable]
    public class CharLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public int baseDamage;
        public float baseResistance;
        public float maxEncumberance;
    }

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

    public CharLevelUps[] charLevelUps;

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

    public void EquipWeapon(ItemPickUp weaponPickUp, CharacterInventory charInventory, GameObject weaponSlot)
    {
        weapon = weaponPickUp;
        currentDamage = baseDamage + weapon.itemDefinition.itemAmount;

    }

    public void EquipArmour(ItemPickUp armourPickup, CharacterInventory characterInventory)
    {
        switch (armourPickup.itemDefinition.ItemArmourSubType)
        {
            case ItemArmourSubType.Head:
                headArmour = armourPickup;
                currentResistance += armourPickup.itemDefinition.itemAmount;
                break;
            case ItemArmourSubType.Chest:
                chestArmour = armourPickup;
                currentResistance += armourPickup.itemDefinition.itemAmount;
                break;
            case ItemArmourSubType.Hands:
                handArmour = armourPickup;
                currentResistance += armourPickup.itemDefinition.itemAmount;
                break;
            case ItemArmourSubType.Legs:
                legArmour = armourPickup;
                currentResistance += armourPickup.itemDefinition.itemAmount;
                break;
            case ItemArmourSubType.Feet:
                feetArmour = armourPickup;
                currentResistance += armourPickup.itemDefinition.itemAmount;
                break;
        }
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeMana(int amount)
    {
        currentMana -= amount;

        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }

    private void Death()
    {

    }
}
