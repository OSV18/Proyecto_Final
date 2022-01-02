using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourGenerator : MonoBehaviour
{
    //[SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private GameObject[] resourcePrefabs;

    [SerializeField] private int minSecon = 4;
    [SerializeField] private int maxSecon = 300;

    private bool isPickedUP;
    private object active;

    public static event Action onPickUP;

    void Start()
    {
        //StartCoroutine(Resource());
    }
    void Update()
    {

        
    }

    IEnumerator Resource()
    {
        while (true)
        {
            int rngSecond = UnityEngine.Random.Range(minSecon, maxSecon);
            yield return new WaitForSeconds(rngSecond);
            SpawnResource();
        }
    }
    void SpawnResource()
    {
        int resourceIndex = UnityEngine.Random.Range(0, resourcePrefabs.Length);
        Instantiate(resourcePrefabs[resourceIndex], transform.position, resourcePrefabs[resourceIndex].transform.rotation);

        isPickedUP = false;
    }

    private void ActiveResource()
    {
        gameObject.SetActive(false);
        isPickedUP = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Resource());
        }
    }

}

