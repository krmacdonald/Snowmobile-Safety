using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public string LevelChange;
   
    public void LoadScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
