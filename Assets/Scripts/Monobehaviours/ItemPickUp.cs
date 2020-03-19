using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUp_SO itemDefinition;
    public CharacterStats characterStats;

    private CharacterInventory _inventory;
    private GameObject _foundStats;

    public ItemPickUp()
    {
        _inventory = CharacterInventory.instance;
    }

    private void Start()
    {
        if (characterStats != null)
        {
            _foundStats = GameObject.FindWithTag("Player");
            characterStats = _foundStats.GetComponent<CharacterStats>();
        }
    }

    private void StoreItemInInventory()
    {
        _inventory.StoreItem(this);
    }

    public void UseItem()
    {
        switch (itemDefinition.itemType)
        {
            case ItemTypeDefinitions.ARMOUR:
                {
                    characterStats.ChangeArmour(this);
                    break;
                }
            case ItemTypeDefinitions.BUFF:
                break;
            case ItemTypeDefinitions.EMPTY:
                break;
            case ItemTypeDefinitions.HEALTH:
                {
                    characterStats.ApplyHealth(itemDefinition.itemAmount);
                    break;
                }

            case ItemTypeDefinitions.MANA:
                {
                    characterStats.ApplyMana(itemDefinition.itemAmount);
                    break;
                };
            case ItemTypeDefinitions.WEALTH:
                {
                    characterStats.GiveWealth(itemDefinition.itemAmount);
                    break;
                }
            case ItemTypeDefinitions.WEAPON:
                {
                    characterStats.ChangeWeapon(this);
                    break;
                }
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (itemDefinition.isStorable)
            {
                StoreItemInInventory();
            }
            else
            {
                UseItem();
            }
        }
    }
}
