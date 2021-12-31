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
    [SerializeField] private float x, y;
    [SerializeField] private float energy = 100;

    [SerializeField] private Transform cam;
    [SerializeField] private Transform cam2;
    [SerializeField] float mouseSesitivity = 2f;
    [SerializeField] Animator animaPlayer;
    [SerializeField] private Image lifeBar;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject myObjetct;
    private float Gavity = -9.81f;

    private bool isGrounded = true;
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
        animaPlayer.SetBool("isJump", false);
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
        Jump();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (isGrounded)
            {

                Jump();
            }

                        
        }*/

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

        energy = Mathf.Clamp(energy, 0, 100);
        energyBar.fillAmount = energy / 100;
        energy -= 0.5f * Time.deltaTime;

        if (energy < 0)
        {
            life -= 7 * Time.deltaTime;
        }

        velocity.y += Gavity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        animaPlayer.SetFloat("VelX", x);
        animaPlayer.SetFloat("VelY", y);
    }

    private void RotatePlayer()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation * mouseSesitivity, 0);


    }

    private void Move()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0, y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            animaPlayer.SetBool("isRun", true);
            cc.Move(moveDir.normalized * SpeedPlayer * Time.deltaTime);
        }
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam2.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            animaPlayer.SetBool("isRun", true);
            cc.Move(moveDir.normalized * SpeedPlayer * Time.deltaTime);
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
        else
        {
            isGrounded = false;
        }

        if (other.gameObject.CompareTag("Enemy"))
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
        

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Radiation"))
        {
            Debug.Log("Entro a Zona Radiactiva");
            life -= 0.05f;
            onDamage?.Invoke(true);

            if (life <= 0)
            {

                onDeath?.Invoke();
                myObjetct.SetActive(false);

            }
        }
    }




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 23)
        {
            Debug.Log("no estas en el suelo");
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            onDamage?.Invoke(false);
        }
    }



    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            velocity.y = Mathf.Sqrt(-5f * Gavity);
            animaPlayer.SetBool("isJump", true);
        }

        else
        {
            animaPlayer.SetBool("isJump", false);
        }

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
            life -= 2f;
            onDamage?.Invoke(true);

            if (life == 0f)
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


