using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterStats_SO characterDefinition;
    public CharacterInventory inventory;
    public GameObject characterWeaponSlot;

    public CharacterStats()
    {
        inventory = CharacterInventory.instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!characterDefinition.setManually)
        {
            SetStatsManually();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
        //    characterDefinition.SaveCharacterData();
        }
    }

    private void SetStatsManually()
    {
        characterDefinition.maxHealth = 100;
        characterDefinition.currentHealth = 50;
        characterDefinition.maxMana = 25;
        characterDefinition.currentMana = 10;
        characterDefinition.maxWealth = 500;
        characterDefinition.currentWealth = 0;
        characterDefinition.baseResistance = 0;
        characterDefinition.currentResistance = 0;
        characterDefinition.maxEncumberance = 50f;
        characterDefinition.currentEncumberance = 0f;
        characterDefinition.charExperience = 0;
        characterDefinition.charLevel = 1;

    }

    public void ApplyHealth(int healthAmount)
    {
        characterDefinition.ApplyHealth(healthAmount);
    }
    public void ApplyMana(int manaAmount)
    {
        characterDefinition.ApplyMana(manaAmount);
    }

    public void GiveWealth(int wealthAmount)
    {
        characterDefinition.GiveWealth(wealthAmount);
    }

    public void Damage(int amount)
    {
        characterDefinition.Damage(amount);
    }

    public void TakeMana(int amount)
    {
        characterDefinition.TakeMana(amount);
    }

    public void ChangeWeapon(ItemPickUp weaponPickup)
    {
        if(!characterDefinition.UnequipWeapon(weaponPickup, inventory, characterWeaponSlot))
        {
            characterDefinition.EquipWeapon(weaponPickup, inventory, characterWeaponSlot);
        }
    }

    public void ChangeArmour(ItemPickUp armourPickup)
    {
        if (!characterDefinition.UnequipArmour(armourPickup, inventory))
        {
            characterDefinition.EquipArmour(armourPickup, inventory);
        }
    }
        
    public int GetHealth()
    {
        return characterDefinition.currentHealth;
    }

    public ItemPickUp GetCurrentWeapon()
    {
        return characterDefinition.weapon;
    }

 
}
