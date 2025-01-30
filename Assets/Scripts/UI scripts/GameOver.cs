using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

   public void Relive()
    {
        AudioSourceController.Instance.PlayMusic("Level");
        SceneManager.LoadScene(2);
        //Collectable.Count = 0;
    }
    public void TitleScreen()
    {
        AudioSourceController.Instance.PlayMusic("Title");
        SceneManager.LoadScene(0);
       // Collectible.CollectionCount = 0;
        
    }
}
