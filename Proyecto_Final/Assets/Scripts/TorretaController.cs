using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaController : MonoBehaviour
{
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private int shootCooldown;
    [SerializeField] private float timeSoot;
    [SerializeField] private GameObject bulletPrefab;
    
    private bool torretShoot = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (torretShoot)
        {
            RaycastTorreta();
        }
        else
        {
            timeSoot += Time.deltaTime;
        }
        if (timeSoot > shootCooldown)
        {
            torretShoot = true;
        }
    }


    private void RaycastTorreta()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            Debug.Log("GOLPEO");
            if (hit.transform.tag == "Enemy")
            {
                torretShoot = false;
                timeSoot = 0;
                GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.forward) * 10f, ForceMode.Impulse);
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (torretShoot)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward) * distanceRay);
        }
    }
}