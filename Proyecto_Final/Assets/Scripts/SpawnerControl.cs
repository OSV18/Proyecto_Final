using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    enum Difficulmode { Easy =1, Normal, Hart};
    [SerializeField] float startDelay = 2f;
    [SerializeField] float spawnlapso = 2f;
    [SerializeField] Difficulmode difficulty;
    [SerializeField] GameObject enemys;
    [SerializeField] private GameObject myObjetct;



    // Start is called before the first frame update
    void Start()
    {
        switch (difficulty)
        {
            case Difficulmode.Easy:
                InvokeRepeating("SpawndEnemy", (startDelay + 3f), (spawnlapso + 3f));
                break;
            case Difficulmode.Normal:
                InvokeRepeating("SpawndEnemy", startDelay, spawnlapso);
                break;
            case Difficulmode.Hart:
                InvokeRepeating("SpawndEnemy", (startDelay - 1f), (spawnlapso - 2f));
                break;
        }

        PlayerContoller.onDeath += OnDeadHandle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawndEnemy()
    {
        Instantiate(enemys,transform.position, enemys.transform.rotation);
    }

    private void OnDeadHandle()
    {
        Destroy(myObjetct);
    }



}
