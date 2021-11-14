using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] float LifePlayer = 3f;
    [SerializeField] float SpeedPlayer = 3F;
    float CameraAxis = 180f;
    [SerializeField] Animator animaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animaPlayer.SetBool("IsRun", false);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        Move();

    }

    private void RotatePlayer()
    {
        CameraAxis += Input.GetAxis("Mouse X");
        Quaternion Angle = Quaternion.Euler(0, CameraAxis, 0);
        transform.localRotation = Angle;

    }

    private void Move()
    {
        float ejehorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");

        if (ejehorizontal != 0 || ejeVertical != 0)
        {
            animaPlayer.SetBool("IsRun", true);
            transform.Translate(SpeedPlayer * Time.deltaTime * new Vector3(ejehorizontal, 0, ejeVertical));
        }
        else
        {
            animaPlayer.SetBool("IsRun", false);
        }

    }
    
        
}

