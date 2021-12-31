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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("golpeado por enemy");
            life -= 2f;
        }
    }
}
