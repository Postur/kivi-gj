using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
   public void RestartButton() {
    SceneManager.LoadScene("Game");
   }
   
   public void ExitButton() {
    SceneManager.LoadScene("done");
   }
}
