using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameManager.typesItem item;

    private bool IsPickedUP;

    private bool equipped;

    private GameObject toolsManager;
    private GameObject tools;
    private bool playersTools;
    private GameObject resourceManager;
    private GameObject resource;
    private bool playersResource;

    private void Start()
    {
        
        
    }

    private void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipped = false;
            }
            if (equipped == false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage()
    {
        /*if (type == "Tools")
        {
            tools.SetActive(true);
            tools.GetComponent<Item>().equipped = true;
        }
        if (type == "Resource")
        {
            resource.SetActive(true);
            resource.GetComponent<Item>().equipped = true;

        }*/
    }

    

    

    public GameManager.typesItem GetTypeItem()
    {
        return item;
    }

    
}
