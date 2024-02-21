using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnowmobileMovement : MonoBehaviour
{
    /*
     * @author kylem
     * @date 2/21/2024
     * Description: This script acts as the main controller for the snowmobile. Uses W as the gas, S for the brake, and A/D to control turn direction
     * Prerequisites: A 3D gameObject with a rigidbody
     */

    /*
     * Additional notes
     * Snowmobile top speed is ~95 miles per hour
     * No reverse on a typical snowmobile
     * 
     * Goals for next ver: 
     */

    //Acceleration vars
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float accelIncrease; //interval the acceleration increases
    [SerializeField]
    private float accelDecrease; //interval the acceleration decreases
    [SerializeField]
    private float accelCap;

    //Speed vars
    public float speed; //public to send this value to the speed display
    private float speedCap;

    //Brake effectiveness
    private float brakeEffectiveness;



    void Start()
    {
        speedCap = 95f; //speed will be 1:1 in comparison to MPH
    }

    void Update()
    {

        //Increase acceleration when drive axis is increased, caps it out if it's too high
        if(Input.GetAxis("Drive") > 0f)
        {
            if (acceleration <= accelCap)
            {
                acceleration += accelIncrease;
            }
            else
            {
                acceleration = accelCap;
            }
        }

        //Slows the snowmobile acceleration down when the player is not accelerating
        if (speed > 0f && acceleration != 0f)
        {
            acceleration -= 1f;
        }
        else if (acceleration < 0f)
        {
            acceleration = 0f;
        }

        //VERY unlikely to be used unless user is being very unsafe. might remove
        if(speed > speedCap)
        {
            speed = speedCap;
        }
    }
}
