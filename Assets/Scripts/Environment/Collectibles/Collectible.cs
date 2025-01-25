using UnityEngine;
using UnityEngine.Events;
using TMPro;
[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    //collection count variables
    public static int Count = 0;//Collection number
   [SerializeField]public TMP_Text CountText;//displays collect count on screen
    public UnityEvent OnCollect;

    public Vector3 spin = Vector3.zero;

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
            collection();
            OnCollect.Invoke();
            Destroy(gameObject);
        }
    }

    //collection method
    public void collection()
    {
        Count ++;
        CountText.text = Count.ToString("0");
    }
}
