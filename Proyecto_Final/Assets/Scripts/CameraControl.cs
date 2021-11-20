using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] int indexCamera = 0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            indexCamera++;
            if (indexCamera == cameras.Count)
            {
                indexCamera = 0;
            }
            SwitchCameras(indexCamera);
        }
    }

    void SwitchCameras(int index)
    {
        foreach (var camera in cameras)
        {
            camera.SetActive(false);
        }
        cameras[index].SetActive(true);
    }

}