using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    [SerializeField] Vector3 cicleDay = new Vector3(1f, 0, 0);
    [SerializeField] private Light[] streetLight;
   
    
    // Start is called before the first frame update
    void Start()
    {
     
        GetComponent<Rigidbody>().angularVelocity = cicleDay;
    }

    // Update is called once per frame
    void Update()
    {
       
        
            
       
      
    }

    private void ActivateLight()
    {
        for (int i = 0; i < streetLight.Length; i++)
        {
            streetLight[i].enabled = true;
            if (cicleDay.x >= 180f)
            {
                streetLight[i].enabled = false;
            }


        }
    }

}

   

