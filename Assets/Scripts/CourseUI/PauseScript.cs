using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	public GameObject Pausescreen;
	public GameObject Pausebutton;
	public string SceneName;
	public string ExitSceneName;

   public void Start()
   {
		//Pausescreen starts inactive
		Pausescreen.SetActive(false);
   }

   public void PauseGame()
   {
		//Stops game time, pause screen appears and pause button disappears
	    Time.timeScale = 0;
		Pausescreen.SetActive(true);
		Pausebutton.SetActive(false);
   }

   public void ResumeGame()
   {
		//Resumes game time, pause screen disappears and pause button appears
		Time.timeScale = 1;
		Pausescreen.SetActive(false);
		Pausebutton.SetActive(true);
   }

   public void ResetGame()
   {
		SceneManager.LoadScene(SceneName);
   }

   public void ExitGame()
   {
		SceneManager.LoadScene(ExitSceneName);
   }
}
