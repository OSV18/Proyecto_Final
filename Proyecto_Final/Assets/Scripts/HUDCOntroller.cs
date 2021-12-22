using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDCOntroller : MonoBehaviour
{
    [SerializeField] private Text textFirst;
    [SerializeField] private Text textCannet;
    [SerializeField] private Text textWater;

    [SerializeField] private TextMeshProUGUI textLive;

    [SerializeField] private InventoryManagers mgInventory;
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image enegyBar;
    private float life;
    private float energy;


    // Start is called before the first frame update
    void Start()
    {
        PlayerContoller.onDeath += OnDeadHandler;

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
        GameManager.Instance.addScore();
        
    }

    void EnergyBar()
    {
        GameManager.Instance.SetEnergy(100);
        GameManager.Instance.GetEnergy();
        energy = Mathf.Clamp(energy, 0, 100);
        enegyBar.fillAmount = energy / 100;
    }

    private void OnDeadHandler()
    {
        textLive.text = "Game Over";
    }


}
