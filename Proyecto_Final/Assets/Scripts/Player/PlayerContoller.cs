using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] float SpeedPlayer = 4F;
    float CameraAxis = 180f;
    [SerializeField] float speedTun;
    [SerializeField] Animator animaPlayer;

    private InventoryManagers mgInventory;
    private Rigidbody rbPlayer;


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

    }

}

