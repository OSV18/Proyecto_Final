using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float LifePlayer = 3f;
    [SerializeField] float SpeedPlayer = 2f;
    [SerializeField] Vector3 initiPosition = new Vector3(0f, 0f, 14f);
    [SerializeField] GameObject GunPlayer;
    [SerializeField] Vector3 Gunposition = new Vector3(0f, 0f, 15f);
    float cameraAxis = 180F;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = initiPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Rotateplayer();
        Move();
        
    }

    private void Move()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");
        transform.Translate(SpeedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
    }

    private void Rotateplayer()
    {

        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion angle = Quaternion.Euler(0, cameraAxis, 0);
        transform.localRotation = angle;
    }
}
