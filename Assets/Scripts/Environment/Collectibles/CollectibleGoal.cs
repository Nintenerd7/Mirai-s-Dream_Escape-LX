using UnityEngine;
using UnityEngine.Events;

public class CollectibleGoal : MonoBehaviour
{
    public int CollectiblesToOpen = 3;
    // Start is called before the first frame update

    public UnityEvent OnOpen;
    void Start()
    {
        CollectibleManager.instance.OnCollectiblePickedUp.AddListener(OnCollectiblePickedUp);
    }

    private void OnCollectiblePickedUp(int count)
    {
        if (count >= CollectiblesToOpen)
        {
            Debug.Log("Enough collectibles picked up. Opening door " + gameObject.name);
            OnOpen.Invoke();
        }
    }
}
