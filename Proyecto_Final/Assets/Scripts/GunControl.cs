using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] float coolDown = 0.5f;
    [SerializeField] float cantBullet = 12f;

    float timeFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && cantBullet > 0)
        {
            if (Time.time > timeFire)
            {
                GameObject newBullet = Instantiate(spawn.GetComponent<SpaBulletControl>().bullet , transform);
                newBullet.transform.position = spawn.transform.position;
                cantBullet -= 1;

                timeFire = Time.time + coolDown;
            }
        }
    }
}
