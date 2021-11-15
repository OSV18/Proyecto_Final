using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] float speedEnemy = 4f;
    [SerializeField] float attackRange = 1f;

    
    private GameObject player;
    private Rigidbody rbEnemy;
    private Animator animaEnemy;

    //private bool isWalk = false;
    private bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();
        animaEnemy = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animaEnemy.SetBool("isAttack", isAttack);
    }

    private void FixedUpdate()
    {
        Vector3 playerDirection = GetPlayerDirection();
        if (playerDirection.magnitude > attackRange)
        {
            isAttack = false;
            rbEnemy.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
            rbEnemy.AddForce(playerDirection.normalized * speedEnemy,ForceMode.Impulse);
        }
        else 
        {
            isAttack = true;
        }

    }  
 


    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;

    }

    
    
}
