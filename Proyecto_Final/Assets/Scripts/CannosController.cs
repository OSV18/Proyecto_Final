using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] cannons;
    [SerializeField] GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        DiseableCannos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DiseableCannos()
    {
        for (int i = 0; i < cannons.Length; i++)
        {
            cannons[i].SetActive(false);

        }
    }


    /*private void ActiveOne()
    {
        int cannonInde = Random.Range(0, cannons.Length);
        get


    }

    /*private CannonController GetCannonComponent(GameObject.target)
    {
        return cannon.GetComponent
    }*/
    
}
