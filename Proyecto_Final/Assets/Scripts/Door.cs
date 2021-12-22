using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{
    private float smooth = 2;
    private float doorAngle = 90;
    private bool open = true;
    private bool enter = false;
    private  Vector3 defaultRot;
    private Vector3 openRot = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(0, defaultRot.y + doorAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Vector3 vector3 = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            transform.eulerAngles = vector3;

        }
        else
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles,defaultRot,Time.deltaTime*smooth);
        }

        if (Input.GetKeyDown("f") && enter)
        {

        }

    }

}
