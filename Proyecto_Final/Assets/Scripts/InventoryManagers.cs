using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagers : MonoBehaviour
{
    [SerializeField] private int[] consumablesQuantity = { 0, 0, 0};
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            GameObject itemPickedUp = other.gameObject;

            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
        }
    }

    public void AddItem(GameObject itemObjet, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObjet.GetComponent<Item>().pickedUP = true;

                slot[i].GetComponent<Slot>().item = itemObjet;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescription;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObjet.transform.parent = slot[i].transform;
                itemObjet.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empty = false;

                return;
            }
     
        
        }
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
            case GameManager.typesConsumables.Water:
                consumablesQuantity[2]++;
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
