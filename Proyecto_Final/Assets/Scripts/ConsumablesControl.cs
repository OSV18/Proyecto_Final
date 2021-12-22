using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesControl : MonoBehaviour
{
    [SerializeField] private GameManager.typesConsumables consumables;


    private bool pickedUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameManager.typesConsumables GetTypeConsumable()
    {
        return consumables;
    }
}
