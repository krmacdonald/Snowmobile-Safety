using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    /*
     * @author kylem
     * @date 3/4/2024
     * Description: This script is used to display the speed in MPH using images on the canvas
     * Prerequisites: 10 sprites of numbers for usage in the HUD, Canvas with two images.
     */

    /*
     * Additional notes
     * Number sprites used from https://opengameart.org/content/numbers-0-9-7x10px, good to use without crediting
     * 
     */

    [Header("Number Array")]
    [SerializeField]
    private Sprite[] numberSprites; //This array is always length 10 for digits 0-9
    private int index1;
    private int index2;
    
    //Contains the manipulable hud images
    [Header("HUD Images")]
    [SerializeField]
    private Image num1;
    [SerializeField]
    private Image num2;

    //Snowmobile script we'll get the speed from
    private TestSnowmobileMovement snowmobileScript;
    private GameObject thisSnowmobile;

    //Keeps track of the speed and converts to string
    private float currentSpeed;

    void Start()
    {
        //Gets the snowmobile in the scene and assigns its information to the variables
        thisSnowmobile = GameObject.Find("Snowmobile");
        snowmobileScript = thisSnowmobile.GetComponent<TestSnowmobileMovement>();
    }

    void Update()
    {
        currentSpeed = Mathf.RoundToInt(snowmobileScript.speed);

        index2 = (int)(currentSpeed % 10);
        index1 = (int)((currentSpeed % 100 - index2) / 10);

        num1.sprite = numberSprites[index1];
        num2.sprite = numberSprites[index2];
    }
}
