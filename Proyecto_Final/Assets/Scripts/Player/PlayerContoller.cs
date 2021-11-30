using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] float SpeedPlayer = 4F;
    float CameraAxis = 180f;
    [SerializeField] float speedTun;
    [SerializeField] Animator animaPlayer;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private float life = 100;

    private InventoryManagers mgInventory;
    private Rigidbody rbPlayer;

    //EVENT
    public static event Action onDeath;


    // Start is called before the first frame update
    void Start()
    {
        animaPlayer.SetBool("isRun", false);
        //animaPlayer.SetBool("isFire", false);
        rbPlayer = GetComponent<Rigidbody>();
        mgInventory = GetComponent<InventoryManagers>();
        
    }


    void FixedUpdate()
    {
        Move();
        RotatePlayer();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            
        }
        
        

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
        if(Input.GetAxis("Mouse X") != 0)
        { 
         
            CameraAxis += Input.GetAxis("Mouse X");
            Quaternion Angle = Quaternion.Euler(0, CameraAxis * speedTun, 0);
            transform.rotation = Angle;
        }
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");

        if (ejeHorizontal != 0 || ejeVertical != 0)
        {
            animaPlayer.SetBool("isRun", true);
            rbPlayer.AddRelativeForce(Vector3.forward * SpeedPlayer * ejeVertical, ForceMode.Acceleration);
            rbPlayer.AddRelativeForce(Vector3.right * SpeedPlayer * ejeHorizontal, ForceMode.Acceleration);
        }

        else
        {
            animaPlayer.SetBool("isRun", false);
        }

    }

    private bool isGrounded = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Consumables"))
        {
            //Debug.Log("UN ITEM");
            GameObject consumable = other.gameObject;
            consumable.SetActive(false);
            mgInventory.AddInventory(consumable.name, consumable);
            mgInventory.SeeInventory();
            mgInventory.CountConsum(consumable);
        }
        
        if (other.gameObject.layer == 23)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 23)
        {
            isGrounded = false;
        }
    }

    

    private void Jump()
    {
        Debug.Log("salta");
        rbPlayer.AddForce(0, 1 * jumpForce, 0);

    }


    /*private bool IsGrounded() //SAlto con Raycast//
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
        {
            return true;
        }
        else return false;

    }*/


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].otherCollider.gameObject.CompareTag("Hand Enemy"))
        {
            Debug.Log("golpeado por enemy");
            life -= 5f;
            if (life == 0)
            {
                //onDeath();
                onDeath?.Invoke();
            }
        }
    }


}


