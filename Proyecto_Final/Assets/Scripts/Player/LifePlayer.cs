using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    [SerializeField] private Image lifeBar;
    
    [SerializeField] private float life = 100;

    void Update()
    {
        life = Mathf.Clamp(life, 0, 100);
        lifeBar.fillAmount = life / 100;
    }
}
