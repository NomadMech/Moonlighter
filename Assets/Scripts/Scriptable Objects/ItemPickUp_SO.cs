using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions
{
    HEALTH,
    WEALTH,
    MANA,
    WEAPON,
    ARMOUR,
    BUFF,
    EMPTY
}

public enum ItemArmourSubType
{
    None, 
    Head, 
    Chest, 
    Hands, 
    Legs, 
    Feet
}



[CreateAssetMenu(fileName = "New Item", menuName = "Spawnable Item/New Pick-up", order = 1)]
public class ItemPickUp_SO : ScriptableObject
{
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.HEALTH;
    public ItemArmourSubType ItemArmourSubType = ItemArmourSubType.None;

    public int itemAmount = 0;
}
