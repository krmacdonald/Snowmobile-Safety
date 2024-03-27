using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * @author Kyle Macdonald
 * @date 3/27/2024
 * Prerequisite: Array assigned to images of hand movements, and an image UI component on screen
 * Output: Hand signals that change based on 1-5 being pressed
 */

public class HandSignal : MonoBehaviour
{
    [SerializeField]
    private Sprite[] indicatorImages; //Array that contains the different sprites of hand signals
    [SerializeField]
    private Image hudImage; //Image on the hud that displays the hand signal
    [SerializeField]
    private float displayDuration; //Amount of time the image is displayed
    [SerializeField]
    private float delayBetween; //Delay between hand signals
    private float timeCounter = 99; //Variables tracks time passed
    private string currentState; //Used in other scripts to detect if player is doing the correct hand signal

    void Update()
    {
        //Depending on what key is held down (1-5) change the image to the corresponding sprite in the array. Pls comment which num is which signal so
        //that text is possible to display in the future

        //If enough time has passed, set the current state of the turn signal to a different string

        timeCounter += Time.deltaTime; //Clock that forever increases

        if (timeCounter > delayBetween)
        {
            if (Input.GetKey("1"))
            {
                currentState = "Right Turn";
                timeCounter = 0;
            }
            else if (Input.GetKey("2"))
            {
                currentState = "Left Turn";
                timeCounter = 0;
            }
            else if (Input.GetKey("3"))
            {
                currentState = "Stop";
                timeCounter = 0;
            }
            else if (Input.GetKey("4"))
            {
                currentState = "Oncoming Sled";
                timeCounter = 0;
            }
            else if (Input.GetKey("5"))
            {
                currentState = "Sleds Following";
                timeCounter = 0;
            }
        }

        //Displays the corresponding hand signal for x seconds
        if (timeCounter < displayDuration)
        {
            hudImage.gameObject.SetActive(true);
            switch (currentState)
            {
                case "Right Turn":
                    hudImage.sprite = indicatorImages[0];
                    break;
                case "Left Turn":
                    hudImage.sprite = indicatorImages[1];
                    break;
                case "Stop":
                    hudImage.sprite = indicatorImages[2];
                    break;
                case "Oncoming Sled":
                    hudImage.sprite = indicatorImages[3];
                    break;
                case "Sleds Following":
                    hudImage.sprite = indicatorImages[4];
                    break;
                default:
                    Debug.Log("not supposed to see this");
                    break;
            }
        }
        else
        {
            //Deactivates the image display and sets the current image to nothing while the image isn't displayed
            hudImage.gameObject.SetActive(false);
            hudImage.sprite = null;
        }
    }
}
