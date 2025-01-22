using UnityEngine;
using UnityEngine.UI;

public class PlayerHearts : MonoBehaviour
{
    public GameObject HeartsGameobjectParent;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public int MaxPlayerHealth = 3;
    public int PlayerHealth = 3;

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
        UpdateHearts();
    }

    public void Heal(int heal)
    {
        PlayerHealth += heal;
        UpdateHearts();
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        MaxPlayerHealth = newMaxHealth;
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        if (PlayerHealth > MaxPlayerHealth)
        {
            PlayerHealth = MaxPlayerHealth;
        }

        Debug.Log("Updating Hearts");
        while(HeartsGameobjectParent.transform.childCount > MaxPlayerHealth)
        {
            DestroyImmediate(HeartsGameobjectParent.transform.GetChild(HeartsGameobjectParent.transform.childCount - 1).gameObject);
        }
        

        for(int i = 0; i < MaxPlayerHealth; i++)
        {
            if (i >= HeartsGameobjectParent.transform.childCount)
            {
                GameObject newHeart = new("Heart " + i);
                newHeart.transform.parent = HeartsGameobjectParent.transform;
                newHeart.transform.localScale = new Vector3(1, 1, 1);
                newHeart.AddComponent<Image>();
            }

            Transform heart = HeartsGameobjectParent.transform.GetChild(i);
            if(i < PlayerHealth)
            {
                heart.GetComponent<Image>().sprite = FullHeart;
            }
            else
            {
                heart.GetComponent<Image>().sprite = EmptyHeart;
            }
        }
    }

    public void OnValidate()
    {
        UnityEditor.EditorApplication.delayCall += () =>
        {
            UpdateHearts();
        };
    }
}
