using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns
{
    public ItemPickUp_SO[] itemDefinitions;
    public Rigidbody itemSpawned { get; set; }
    public Renderer itemMaterial { get; set; }
    public ItemPickUp itemType { get; set; }

    private int whichToSpawn = 0;
    private int totalSpawnWeight = 0;
    private int chosen = 0;

    public void CreateSpawn()
    {
        foreach (var item in itemDefinitions)
        {
            whichToSpawn += item.spawnChanceWeight;
            if(whichToSpawn >= chosen)
            {
                itemSpawned = Instantiate(item.itemSpawnObject, transform.position, Quaternion.identity);

                itemMaterial = itemSpawned.GetComponent<Renderer>();
                itemMaterial.material = item.itemMaterial;

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = item;
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(var item in itemDefinitions)
        {
            totalSpawnWeight += item.spawnChanceWeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
