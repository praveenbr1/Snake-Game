using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
   int currentScenIndex;

   private void Start() 
   {
    currentScenIndex = SceneManager.GetActiveScene().buildIndex;
   }

   public void LoadNextScene()
   {
        SceneManager.LoadScene(currentScenIndex + 1);
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
