using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static CharacterInventory instance;

    private void Start()
    {
        instance = this;
    }

    public void StoreItem(ItemPickUp itemToStore)
    {

    }

    private void TryPickUp()
    {

    }

    private bool AddItemToInventory(bool finishedAdding)
    {
        return true;
    }

    private void AddItemToHotBat(InvetoryEntry itemForHotBar)
    {

    }

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
