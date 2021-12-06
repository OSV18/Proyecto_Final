using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TorretActivator : MonoBehaviour
{
    [SerializeField] private UnityEvent onTorretActivator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTorretActivator?.Invoke();
        }
    }




}
