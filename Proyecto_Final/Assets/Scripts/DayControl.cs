using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    [SerializeField] Vector3 cicleDay = new Vector3(1f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = cicleDay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
