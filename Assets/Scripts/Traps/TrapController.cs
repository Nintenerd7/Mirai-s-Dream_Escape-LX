using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TrapController : MonoBehaviour
{
    public bool trapPrimed = true;
    public UnityEvent OnTrapTriggered;

    public void OnTriggerStay(Collider other)
    {
        if (trapPrimed && other.CompareTag("Player"))
        {
            Debug.Log("Trap triggered");
            trapPrimed = false;
            OnTrapTriggered.Invoke();
        }
    }

    public void ResetTrap()
    {
        trapPrimed = true;
    }
}
