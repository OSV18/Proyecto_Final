using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{

    [SerializeField] private AudioClip geigerSound;
    private AudioSource audioRadiation;

    // Start is called before the first frame update
    void Start()
    {
        audioRadiation = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (!audioRadiation.isPlaying)
            {
                audioRadiation.PlayOneShot(geigerSound, 0.1f);
            }
        }
    }
}

