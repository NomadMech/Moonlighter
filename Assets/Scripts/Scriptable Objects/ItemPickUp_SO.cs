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
    public string itemName = "New Item";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.HEALTH;
    public ItemArmourSubType ItemArmourSubType = ItemArmourSubType.None;
    public int itemAmount = 0;
    public int spawnChanceWeight = 0;

    public Rigidbody itemSpawnObject = null;
    public Material itemMaterial = null;
    public Sprite itemIcon = null;
    public Rigidbody itemSpawnPoint = null;
    public Rigidbody weaponSlotObject = null;

    public bool isEquipped = false;
    public bool isInteractable = false;
    public bool isStorable = false;
    public bool isUnique = false;
    public bool isIndestructable = false;
    public bool isQuestItem = false;
    public bool isStackable = false;
    public bool destroyOnUse = false;

    public float itemWeight = 0f;
}
