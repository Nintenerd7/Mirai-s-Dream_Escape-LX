using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SpikeTrap : MonoBehaviour
{
    private bool _spikeTriggered = false;
    private bool _alreadyHitPlayer = false;

    [Tooltip("The distance that the spikes will travel on trigger")]
    public float SpikeDistance = 1;
    public float SpikeTimeToExtend = 0.4f;
    public float SpikeTimeFullyExtended = 1;
    public float RetractionTime = 3;
    public int Damage = 1;


    public TrapController trapController;

    public void TriggerSpikes() {
        if (_spikeTriggered) return;
        _spikeTriggered = true;
        StartCoroutine(ExtendSpikes(SpikeTimeToExtend));
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && !_alreadyHitPlayer && _spikeTriggered) {
            Debug.Log("Hit Player");
            _alreadyHitPlayer = true;
            other.GetComponent<PlayerHearts>().TakeDamage(Damage);}
    }

    private IEnumerator ExtendSpikes(float timeToExtend) {
        float elapsedTime = 0;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.up * SpikeDistance;
        while (elapsedTime < timeToExtend) {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / timeToExtend);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        yield return new WaitForSeconds(SpikeTimeFullyExtended);
        StartCoroutine(RetractSpikes(RetractionTime));
    }

    private IEnumerator RetractSpikes(float timeToRetract) {
        float elapsedTime = 0;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = transform.position - transform.up * SpikeDistance;
        while (elapsedTime < timeToRetract) {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / timeToRetract);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        
        ResetState();
    }

    private void ResetState() {
        _alreadyHitPlayer = false;
        _spikeTriggered = false;

        if (trapController != null)
        {
            trapController.ResetTrap();
        }
    }
}
