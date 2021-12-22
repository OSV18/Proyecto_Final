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
