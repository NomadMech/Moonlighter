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
}
