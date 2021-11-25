using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCOntroller : MonoBehaviour
{
    [SerializeField] private Text textFirst;
    [SerializeField] private Text textCannet;
    [SerializeField] private InventoryManagers mgInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateConsumableUI();
    }

    void UpdateConsumableUI()
    {
        int[] consumCount = mgInventory.GetConsumablesQuantity();
        textFirst.text ="x" + consumCount[0];
    }
}
