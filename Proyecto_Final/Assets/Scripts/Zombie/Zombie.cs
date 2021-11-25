using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] protected float speedEnemy = 50f;
    [SerializeField] private GameObject originOne;
    [SerializeField] private float distanceRay = 10;

    protected Rigidbody rbZombie;
    private Animator animaZombie;

    private bool isAttack = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rbZombie = GetComponent<Rigidbody>();
        animaZombie = gameObject.transform.GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        if (!isAttack)
        {
            FindEnemy();
            Move();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Move()
    {
        Vector3 direction = Vector3.left;
        rbZombie.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        rbZombie.AddForce(direction * speedEnemy, ForceMode.Impulse);

    }

    public virtual void FindEnemy()
    {
        BroacastRaycast(originOne.transform);
    }

    protected void BroacastRaycast(Transform origen)
    {
        RaycastHit hit;
        if (Physics.Raycast(origen.position, origen.TransformDirection(Vector3.forward), out hit, distanceRay))
        {
            if (hit.transform.CompareTag ("Player"))
            {
                isAttack = true;
                rbZombie.velocity = Vector3.zero;
                animaZombie.SetBool("isAttack", isAttack);
            }
            else
            {
                isAttack = false;
            }
                  
        }
    }

    protected void DrawrRay(Transform origen)
    {
        Gizmos.color = Color.green;
        Vector3 direction = origen.TransformDirection(Vector3.forward) * distanceRay;
        Gizmos.DrawRay(origen.position, direction);
    }

    private void OnDrawGizmos()
    {
        if (!isAttack)
        {
            DrawrRay(originOne.transform);
        }
          
    }
}

