using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    //collection count variables
    public UnityEvent OnCollect;
    public Vector3 spin = Vector3.zero;

    void Start()
    {
        OnCollect.AddListener(CollectibleManager.instance.NotifyCollectiblePickup);
    }

    void Update()
    {
        if (spin != Vector3.zero)
        {
            transform.Rotate(spin * Time.deltaTime);
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
