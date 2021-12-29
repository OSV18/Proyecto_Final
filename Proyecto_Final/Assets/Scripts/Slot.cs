using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public GameObject item;
    [SerializeField] public int ID;
    [SerializeField] public string type;
    [SerializeField] public string description;
    [SerializeField] public Sprite icon;

    public Transform slotIconGameObjet;
    public bool empty;


    public void Start()
    {
        slotIconGameObjet = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotIconGameObjet.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }
    
       
    

    public bool SetEmpty()
    {
        return empty;
    }

}
