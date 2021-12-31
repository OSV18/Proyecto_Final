using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourGenerator : MonoBehaviour
{
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private GameObject[] resourcePrefabs;

    [SerializeField] private int minSecon = 4;
    [SerializeField] private int maxSecon = 300;

    private bool pickedUP;
    private object active;
    void Start()
    {
        StartCoroutine(Resource());
    }
    void Update()
    {

        
    }

    IEnumerator Resource()
    {
        while (true)
        {
            int rngSecond = Random.Range(minSecon, maxSecon);
            yield return new WaitForSeconds(rngSecond);
            SpawnResoruse();
            
        }
    }
    void SpawnResoruse()
    {
        int resourceIndex = Random.Range(0, resourcePrefabs.Length);
        Instantiate(resourcePrefabs[resourceIndex], transform.position, resourcePrefabs[resourceIndex].transform.rotation);
    }

    private void ActiveResourse()
    {
        gameObject.SetActive(false);
        pickedUP = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //SpawnResoruse();
        }
    }

}

