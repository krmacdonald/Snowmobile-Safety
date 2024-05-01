using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @author Kyle Macdonald
 * @date 3/20/24
 * prerequisite: Snowmobile prefab, colliders in level with tag "crashable", triggers with tag "Offroad Trigger" event manager script that pops up the crash prompt
 * output: Calls the crash popup 
 */

public class SnowmobileCrash : MonoBehaviour
{
    //Gets the crashpopup script, usually attached to the canvas
    [SerializeField]
    private CrashPopup eventManager;

    //Progress Bar dragged in, allows it to be accessed
    [SerializeField]
    private Image BarFill;

    //Handles collisions with solid objects like trees and steep hills
    void OnCollisionEnter(Collision other)
    {
        //checks if the object the player collided with is something you can crash into
        

        
    }

    //Handles checks on invisible obstacles like npc riders + off roading
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Crashable")
        {
            //Calls the callPopup method for the event manager to display what the player did wrong
            eventManager.callPopup("Crash");

            //Resets Progress Bar
            BarFill.fillAmount = 0f;
        }
        //Checks tag of the trigger to see if its the offroad trigger
        if (other.gameObject.tag == "Offroad Trigger")
        {
            //calls popup with the parameter offtrack to let the user know they went off track
            eventManager.callPopup("offTrack");

            //Resets Progress Bar
            BarFill.fillAmount = 0f;
        }

        //checks if the object the player collided with is an AI Rider
        if (other.gameObject.tag == "AI Rider")
        {
            //Calls the popup method for the event manager to display what the player did wrong
            eventManager.callPopup("AI Rider Collision");
        }
    }


    
}
