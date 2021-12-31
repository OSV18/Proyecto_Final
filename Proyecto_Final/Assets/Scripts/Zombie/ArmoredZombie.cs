using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoredZombie : Zombie
{
 

    [SerializeField] Transform[] waypoints;


    private bool goBack = false;
    private int currenIndex = 0;

    public override void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= myData.rangeOfView)
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
            Move();
        }


    }

    public override void Move()
    {       
        Vector3 deltavector = waypoints[currenIndex].position - transform.position;
        Vector3 direction = deltavector.normalized;
        rbZombie.AddForce(direction.normalized * myData.speed, ForceMode.Impulse);
        rbZombie.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));


            float distance = deltavector.magnitude;


            if (distance < myData.minimDistan)
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
    private void ChasePlayer()
    {
        Vector3 playerDirection = GetPlayerDirection();
        rbZombie.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        rbZombie.AddForce(playerDirection * myData.speed, ForceMode.Impulse);
    }

    public override Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (iSeePlayer)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.blue;
        }

        Gizmos.DrawWireSphere(transform.position, myData.rangeOfView);
    }
}

