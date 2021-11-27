using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 50f;
    [SerializeField] float attackRange = 1f;
    //[SerializeField] private float distanceRay = 10f;
    //[SerializeField] private GameObject visionPoint;

    [SerializeField] float rangeOfView;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float minimDistan;
    [SerializeField] float rotationSpeed;
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

        
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= rangeOfView)
        {
            iSeePlayer = true;
        }
        else
        {
            iSeePlayer = false;
        }

        if (iSeePlayer)
        {
            ChasePlayer();
        }
        else
        {
            MovementWayp();
        }
    }  
 


    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;

    }
    private void OnCollisionEnter(Collision collision)
    {
        

    }

    /*private void RaycastEnemy()
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
        
    }*/

    private bool iSeePlayer = false;
    private void ChasePlayer()
    {
        Vector3 playerDirection = GetPlayerDirection();
        if (playerDirection.magnitude > attackRange)
        {
            isAttack = false;
            rbEnemy.AddForce(playerDirection.normalized * speedEnemy, ForceMode.Impulse);
            rbEnemy.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        }
        else
        {
            isAttack = true;
     
        }
}

    private void OnDrawGizmos()
    {
        if (iSeePlayer)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.blue;
        }

        Gizmos.DrawWireSphere(transform.position, rangeOfView);
    }

    private bool goBack = false;

    private void MovementWayp()
    {
        Vector3 deltavector = waypoints[currenIndex].position - transform.position;
        Vector3 direction = deltavector.normalized;
        rbEnemy.AddForce(direction.normalized * speedEnemy, ForceMode.Impulse);
        rbEnemy.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        

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
