using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public int ID;
    [SerializeField] public string type;
    [SerializeField] public string description;
    [SerializeField] public  Sprite icon;

    [HideInInspector] public bool pickedUP;

    [HideInInspector] public bool equipped;

    private GameObject toolsManager;
    private GameObject tools;
    private bool playersTools;

    private void Start()
    {
        toolsManager = GameObject.FindWithTag("ToolsManager");

        if (!playersTools)
        {
            int alltools = toolsManager.transform.childCount;

            for (int i = 0; i < alltools; i++)
            {
                if (toolsManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID==ID)
                {
                    tools = toolsManager.transform.GetChild(i).gameObject;
                }
            }
        }
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
        if (type == "Tools")
        {
            tools.SetActive(true);
            tools.GetComponent<Item>().equipped = true;
        }
        if (type == "Tools")
        {

        }
    }


    public void SetID(int newID)
    {
        ID = newID;
    }
    public void SetType(string newType)
    {
        type = newType;
    }
    public void SetDescription(string newDescription)
    {
        description = newDescription;
    }
    public void SetIcon(Sprite newIcon)
    {
        icon = newIcon;
    }


    public int GetID()
    {
        return ID;
    }
    public new string GetType()
    {
        return type;
    }
    public string GetDescription()
    {
        return description;
    }
    public Sprite GetIcon()
    {
        return icon;
    }

}
