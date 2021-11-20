using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 50f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private GameObject visionPoint;

    [SerializeField] Transform[] waypoints;
    [SerializeField] float minimDistan;
    private int currenIndex = 0;

    private GameObject player;
    private Rigidbody rbEnemy;
    private Animator animaEnemy;

    
    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();
        animaEnemy = gameObject.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animaEnemy.SetBool("isAttack", isAttack);

        MovementWayp();

    }

    private void FixedUpdate()
    {
        RaycastEnemy();

    }  
 


    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        

    }

    private void RaycastEnemy()
    {
        RaycastHit hit;
        if(Physics.Raycast(visionPoint.transform.position, visionPoint.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            if (hit.transform.tag == "Player")
            {
                Vector3 playerDirection = GetPlayerDirection();
                if (playerDirection.magnitude > attackRange)
                {
                    isAttack = false;
                    rbEnemy.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
                    rbEnemy.AddForce(playerDirection.normalized * speedEnemy, ForceMode.Impulse);
                }
                else
                {
                    isAttack = true;
                }

            }    
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distanceRay);
    }

    private bool goBack = false;

    private void MovementWayp()
    {
        Vector3 deltavector = waypoints[currenIndex].position - transform.position;
        Vector3 direction = deltavector.normalized;
        transform.position += direction * speedEnemy * Time.deltaTime;

        float distance = deltavector.magnitude;
        

        if (distance < minimDistan)
        {
            if (currenIndex >= waypoints.Length - 1)
            {
                goBack = true;
            }
            else if (currenIndex <= 0)
            {
                goBack = false;
            }

            if (!goBack)
            {
                currenIndex++;
            }
            else currenIndex--;

        }


    }



}
