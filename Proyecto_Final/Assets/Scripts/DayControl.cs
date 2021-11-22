using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    [SerializeField] Vector3 cicleDay = new Vector3(1f, 0, 0);
    [SerializeField] private Light[] streetLight;
    [SerializeField] float min;
    [SerializeField] float timeSpeed = 1f;
    [SerializeField] float grados;
    // Start is called before the first frame update
    void Start()
    {
     
        //GetComponent<Rigidbody>().angularVelocity = cicleDay;
    }

    // Update is called once per frame
    void Update()
    {
        min += timeSpeed * Time.deltaTime;
        if (min >= 1440)
        {
            min = 0;
        }


        grados = min / 4;
        transform.localEulerAngles = new Vector3(grados, -90, 0);

        ActivateLight();


    }

    private void ActivateLight()
    {
        for (int i = 0; i < streetLight.Length; i++)
        {
            streetLight[i].enabled = false;
            if (grados >= 180f)
            {
                streetLight[i].enabled = true;
            }


        }
    }

}

   

