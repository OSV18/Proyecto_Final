using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagers : MonoBehaviour
{
    [SerializeField] private int[] itemQuantity = { 0, 0, 0, 0, 0 ,0};
    Dictionary<string, GameObject> inventory;
    private bool inventoreEnabled;
    [SerializeField] private GameObject Inventory;
    private int allSlots;
    private int enableSlot;
    private GameObject[] slot;
    [SerializeField] private GameObject slotHolder;

    

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Dictionary<string, GameObject>();
        allSlots = slotHolder.transform.childCount;

        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoreEnabled = !inventoreEnabled;
        }

        if (inventoreEnabled)
        {
            Inventory.SetActive(true);
        }
        else
        {
            Inventory.SetActive(false);
        }

    }

   
   
    public void CountItem(GameObject item)
    {
        Item c = item.GetComponent<Item>();

        switch (c.GetTypeItem())
        {
            case GameManager.typesItem.Firstaid:
                itemQuantity[0]++;
                break;
            case GameManager.typesItem.Food:
                itemQuantity[1]++;
                break;
            case GameManager.typesItem.Water:
                itemQuantity[2]++;
                break;
            case GameManager.typesItem.Fuel:
                itemQuantity[3]++;
                break;
            case GameManager.typesItem.Mask:
                itemQuantity[4]++;
                break;
            case GameManager.typesItem.Flashlight:
                itemQuantity[5]++;
                break;
            default:
                Debug.Log("NO SE PUEDE CONTAR");
                break;
        }
    }

    public int[] GetItemQuantity()
    {
        return itemQuantity;
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
