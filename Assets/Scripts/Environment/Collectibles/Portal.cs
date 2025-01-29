using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Portal : MonoBehaviour
{
    public string PortalToSceneName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered portal. Switching to scene " + PortalToSceneName);
            CollectibleManager.instance.SwitchToScene(PortalToSceneName);
        }
    }
}
