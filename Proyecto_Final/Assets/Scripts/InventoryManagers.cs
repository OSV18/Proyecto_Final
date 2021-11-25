using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagers : MonoBehaviour
{
    [SerializeField] private int[] consumablesQuantity = { 0, 0};
    Dictionary<string, GameObject> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountConsum(GameObject consumable)
    {
        ConsumablesControl c = consumable.GetComponent<ConsumablesControl>();

        switch (c.GetTypeConsumable())
        {
            case GameManager.typesConsumables.Firstaid:
                consumablesQuantity[0]++;
                break;
            case GameManager.typesConsumables.Canned:
                consumablesQuantity[1]++;
                break;
            default:
                Debug.Log("NO SE PUEDE CONTAR");
                break;
        }
    }

    public int[] GetConsumablesQuantity()
    {
        return consumablesQuantity; 
    }

    public void AddInventory(string key,GameObject item)
    {
        inventory.Add(key, item);
    }
    public GameObject GetInventory(string key)
    {
        return inventory[key] as GameObject;
    }
    public void SeeInventory()
    {
        Debug.Log(inventory.ToString());
        foreach (var item in inventory)
        {
            Debug.Log(item.ToString());
        }
    }
    public bool InventoryHas()
    {
        return inventory.Count > 0;
    }
}
