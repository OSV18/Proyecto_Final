using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControl : MonoBehaviour
{
    [SerializeField] Vector3 cicleDay = new Vector3(1f, 0, 0);
    [SerializeField] private Light[] streetlight;
    //[SerializeField] private Light streetlight1;
    //[SerializeField] private Light streetlight2;
    //[SerializeField] private Light streetlight3;
    //[SerializeField] private Light streetlight4;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = cicleDay;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (cicleDay.x >= 180f)
        {
            //streetlight2.gameObject.SetActive(false);
            streetlight[0].gameObject.SetActive(false);
        }

        else
        {
            streetlight[0].gameObject.SetActive(true);

        }*/
    }
}
