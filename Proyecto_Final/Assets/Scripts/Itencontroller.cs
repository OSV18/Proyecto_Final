using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itencontroller : MonoBehaviour
{

    

   

    // Start is called before the first frame update
    void Start()
    {
        //light = GameObject.GetComponent(Quaternion.Euler(x, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.addScore();
            Destroy(collision.gameObject);
            Debug.Log(GameManager.GetScore());

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
