using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * @author Kyle Macdonald
 * @date 3/20/24
 * prerequisite: Connected to the SnowmobileCrash script, UI element with timeline for animating it to come in on screen
 * output: a box 
 */

public class CrashPopup : MonoBehaviour
{
    [SerializeField]
    private GameObject UIPanel;
    [SerializeField]
    private TMP_Text warningText;

    void Start()
    {
        Time.timeScale = 1; //Resumes game in the case it's paused
        UIPanel.SetActive(false); //Hides the panel with the fail info
    }

    void Update()
    {
        //Resets the HUD components when the player resets their snowmobile
        if (Input.GetKeyDown("r"))
        {

            UIPanel.SetActive(false); //Hides panel
            Time.timeScale = 1; //Resumes game
        }
    }

    public void callPopup(string eventCaused)
    {
        //Takes the parameter eventCaused then displays the appropriate text depending on what happened
        switch (eventCaused)
        {
            case "Crash":
                warningText.text = "Oh no! You crashed! Make sure to slow down when taking turns, there's no time limit when driving a snowmobile!\nPress R to restart";
                break;
            case "offTrack":
                warningText.text = "Oh no! You went off the track for too long. Going off the trail can be dangerous, and can lead to you hurting yourself and others!\nPress R to restart";
                break;
            default:
                Debug.Log("this isn't supposed to be seen"); //Debug in case event isn't found
                break;
        }
        UIPanel.SetActive(true); //Displays the panel
        Time.timeScale = 0; //Pauses the game
    }
}
