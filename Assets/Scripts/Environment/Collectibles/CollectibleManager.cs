using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] public TMP_Text CountText;//displays collect count on screen
    public static CollectibleManager instance;
    private int _collectiblesPickedUp = 0;

    public UnityEvent<int> OnCollectiblePickedUp;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void NotifyCollectiblePickup() {
        _collectiblesPickedUp++;
        Debug.Log("Collectible picked up. Total: " + _collectiblesPickedUp);

        OnCollectiblePickedUp.Invoke(_collectiblesPickedUp);
    }
}
