using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCOntroller : MonoBehaviour
{
    [SerializeField] private Text textFirst;
    [SerializeField] private Text textCannet;
    [SerializeField] private Text textWater;

    [SerializeField] private InventoryManagers mgInventory;
    [SerializeField] private Image lifeBar;
    private float life;

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
        textCannet.text = "x" + consumCount[1];
        textWater.text = "x" + consumCount[2];
    }

    void LifeBar()
    {
        GameManager.Instance.Setlife(100);
        GameManager.Instance.GetLife();
        life = Mathf.Clamp(life, 0, 100);
        lifeBar.fillAmount = life / 100;
    }
  
}
