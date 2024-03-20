using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Handles collisions with solid objects like trees and steep hills
    void OnCollisionEnter(Collision other)
    {
        //checks if the object the player collided with is something you can crash into
        if (other.gameObject.tag == "Crashable")
        {
            //Calls the callPopup method for the event manager to display what the player did wrong
            eventManager.callPopup("Crash");
        }
    }

    //Handles checks on invisible obstacles like npc riders + off roading
    void OnTriggerEnter(Collider other)
    {
        //Checks tag of the trigger to see if its the offroad trigger
        if (other.gameObject.tag == "Offroad Trigger")
        {
            //calls popup with the parameter offtrack to let the user know they went off track
            eventManager.callPopup("offTrack");
        }
    }
}
