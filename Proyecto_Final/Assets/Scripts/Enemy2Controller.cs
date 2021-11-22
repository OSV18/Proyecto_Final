using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 50f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private GameObject visionPoint;

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
        RaycastEnemy();

    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;

    }

    private void RaycastEnemy()
    {
        RaycastHit hit;
        if (Physics.Raycast(visionPoint.transform.position, visionPoint.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
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
}
