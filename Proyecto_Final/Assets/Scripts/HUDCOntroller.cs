using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDCOntroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFirst;
    [SerializeField] private TextMeshProUGUI textFood;
    [SerializeField] private TextMeshProUGUI textWater;
    [SerializeField] private TextMeshProUGUI textFuel;
    [SerializeField] private TextMeshProUGUI textMask;
    [SerializeField] private TextMeshProUGUI textFlashlight;

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
        UpdateItemUI();

    }

    public void UpdateItemUI()
    {
        /*int[] itemCount = mgInventory.GetItemQuantity();
        textFirst.text = "x" + itemCount[0];
        textFood.text = "x" + itemCount[1];
        textWater.text = "x" + itemCount[2];
        textFuel.text = "x" + itemCount[3];
        textMask.text = "x" + itemCount[4];
        textFlashlight.text = "x" + itemCount[5];*/
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
