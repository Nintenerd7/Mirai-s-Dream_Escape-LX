using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    public UnityEvent OnCollect;

    public bool spin = true;

    void Update() {
        if (spin) {
            transform.Rotate(0, 90 * Time.deltaTime, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collectible Triggered");
        if (other.CompareTag("Player"))
        {
            OnCollect.Invoke();
            Destroy(gameObject);
        }
    }
}
