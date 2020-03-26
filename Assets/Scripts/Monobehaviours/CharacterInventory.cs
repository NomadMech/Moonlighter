using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static CharacterInventory instance;
    public CharacterStats charStats;
    public bool addedItem;
    private void Start()
    {
        instance = this;
    }

    public void StoreItem(ItemPickUp itemToStore)
    {
        addedItem = false;

        if((charStats.characterDefinition.currentEncumberance +
            itemToStore.itemDefinition.itemWeight) <= charStats.characterDefinition.maxEncumberance)
        {
            //itemEntry.invEntry = itemToStore;
            //itemEntry.stackSize = 1;
            //itemEntry.hbSprite = itemToStore.itemDefinition.itemIcon;

            itemToStore.gameObject.SetActive(false);
        }
    }

    private void TryPickUp()
    {

    }

    private bool AddItemToInventory(bool finishedAdding)
    {
        return true;
    }

    //private void AddItemToHotBat(InventoryEntry itemForHotBar)
    //{

    //}

    private void DispayInvetory()
    {

    }

    private void FillInventoryDisplay()
    {

    }

    public void TriggerItemUse(int itemToUseId)
    {

    }
}
