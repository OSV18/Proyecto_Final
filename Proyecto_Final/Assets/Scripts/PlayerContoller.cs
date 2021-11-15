using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] float LifePlayer = 3f;
    [SerializeField] float SpeedPlayer = 4F;
    float CameraAxis = 180f;
    [SerializeField] Animator animaPlayer;

    private Rigidbody rbPlayer;


    // Start is called before the first frame update
    void Start()
    {
        animaPlayer.SetBool("isRun", false);
        animaPlayer.SetBool("isFire", false);
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            animaPlayer.SetBool("isAttack", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animaPlayer.SetBool("isAttack", false);
        }
            


    }

    private void RotatePlayer()
    {
        CameraAxis += Input.GetAxis("Mouse X");
        Quaternion Angle = Quaternion.Euler(0, CameraAxis, 0);
        transform.localRotation = Angle;

    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}

