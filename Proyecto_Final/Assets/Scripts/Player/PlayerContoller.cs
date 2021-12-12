using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField] private float life = 100;
    [SerializeField] float SpeedPlayer = 4F;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Transform cam;
    [SerializeField] float mouseSesitivity = 2f;
    [SerializeField] Animator animaPlayer;
    [SerializeField] private Image lifeBar;
    [SerializeField] private GameObject myObjetct;
    private float Gavity = -9.81f;


    private InventoryManagers mgInventory;
    private Rigidbody rbPlayer;
    private CharacterController cc;

    //EVENT
    public static event Action onDeath;
    public static event Action<int> onScore;
    public static event Action<bool> onDamage;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animaPlayer.SetBool("isRun", false);
        //animaPlayer.SetBool("isFire", false);
        mgInventory = GetComponent<InventoryManagers>();
        
    }


    void FixedUpdate()
    {

        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        RotatePlayer();

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

        life = Mathf.Clamp(life, 0, 100);
        lifeBar.fillAmount = life / 100;

        velocity.y += Gavity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);



    }

    private void RotatePlayer()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation * mouseSesitivity, 0);

        
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");
        float ejeVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(ejeHorizontal, 0, ejeVertical).normalized;
        
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            animaPlayer.SetBool("isRun", true);
            cc.Move(moveDir.normalized * SpeedPlayer * Time.deltaTime);
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
        velocity.y = Mathf.Sqrt(-5f * Gavity);

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Golpeado por Enemy");
            life -= 5f;
            onDamage?.Invoke(true);

            if (life == 0)
            {
                
                onDeath?.Invoke();
                myObjetct.SetActive(false);
                
            }
        }
        /*if (collision.contacts[0].otherCollider.gameObject.CompareTag("Hand Enemy"))
        {
            //Debug.Log("golpeado por enemy");
            life -= 5f;
            if (life == 0)
            {
                onDeath();
                onDeath?.Invoke();
            }
        }*/
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            onDamage?.Invoke(false);
        }
    }


}


