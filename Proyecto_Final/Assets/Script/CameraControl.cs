using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject[] cameras;




    // Start is called before the first frame update
    void Start()
    {
        ActivateCameras();
    }

    // Update is called once per frame
    void Update()
    {
        
        SwitchCameras();

    }


       
    void ActivateCameras()
    {
        for (int i = 0; i < cameras.Length ; i++)
        {
            cameras[i].SetActive(false);
        }      
    }

    void SwitchCameras()
    {
        for (int i = 0; i < cameras.Length ; i++)
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                cameras[1].SetActive(true);
            }

        }
    }

        
}