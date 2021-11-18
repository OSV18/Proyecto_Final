using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    
    
    public GameObject Spawn;
    public float Cooldown = 0.1f;
    float timefire = 0;
    ///public bool isShoot = false;
    [SerializeField] float CantProjet = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CantProjet > 0)
        {
            if (Time.time > timefire)
            {

                GameObject newprojectile = Instantiate(Spawn.GetComponent<Spawncontrol>().Projectile[0], transform);
                newprojectile.transform.position = Spawn.transform.position;
                CantProjet -= 1f;

                timefire = Time.time + Cooldown;

            }
            
            
        }
            

        }
        
        


        

}



    
