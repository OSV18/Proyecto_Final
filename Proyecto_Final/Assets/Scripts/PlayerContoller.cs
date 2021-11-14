using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] float LifePlayer = 3f;
    [SerializeField] float SpeedPlayer = 4F;
    float CameraAxis = 180f;
    [SerializeField] Animator animaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animaPlayer.SetBool("isRun", false);
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
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");

        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animaPlayer.SetBool("isRun", true);
            Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical);
            transform.Translate(SpeedPlayer * Time.deltaTime * direction);
        }

        else
        {
            animaPlayer.SetBool("isRun", false);
        }

    }
    
        
}

