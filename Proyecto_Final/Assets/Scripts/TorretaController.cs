using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaController : MonoBehaviour
{
    [SerializeField] private float distanceRay = 10f;
    [SerializeField] private GameObject shootOrigen;
    [SerializeField] private int shootCooldown = 2;
    [SerializeField] private float timeSoot = 1;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Vector3 turnTorett = new Vector3(0, 0, 1f);

    private bool torretShoot = true;
    private Transform target;
    [SerializeField] float range = 15f;
    [SerializeField] Transform ponitRotate;
    [SerializeField] string enemyTap = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().angularVelocity = turnTorett;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
            return;

            RotationTorret();
        

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
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.forward) * 20f, ForceMode.Impulse);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void RotationTorret()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        ponitRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTap);
        float shortesDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearesEnemy = enemy;   
            }
        }
        if (nearesEnemy != null && shortesDistance <= range)
        {
            target = nearesEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

}
