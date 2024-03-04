using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSnowmobileMovement : MonoBehaviour
{
    /*
     * @author kylem
     * @date 3/4/2024
     * Description: This script acts as the main controller for the snowmobile. Uses W as the gas, S for the brake, and A/D to control turn direction
     * Prerequisites: A 3D gameObject with a rigidbody, "driving" on a material with the snowy physics material applied
     */

    /*
     * Additional notes
     * Snowmobile top speed is ~95 miles per hour
     * No reverse on a typical snowmobile
     * Movement is controlled by a rb with pushing it forward, be conscious of gravity
     * 
     * Goals for next ver: Mess around with the values and find good numbers 
     */

    //This gameobject's rigidbody
    private Rigidbody snowmobileRB;

    //Acceleration vars
    [Header("Acceleration Variables")]
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float accelIncrease; //interval the acceleration increases
    [SerializeField]
    private float accelDecrease; //interval the acceleration decreases
    [SerializeField]
    private float accelCap;
    [SerializeField]
    private float accelModifier; //1-inf changes the multiplier on how fast the speed increases
    
    //Speed values
    [Header("Speed Variables")]
    public float speed; //public to send this value to the speed display
    private float speedCap;
    [SerializeField]
    private float speedModifier; // 0-1, divides the speed to match the map
    [SerializeField]
    private float speedDecay; //The rate of speed decrease when not holding forward

    //Brake effectiveness
    [Header("Brake Variables")]
    [SerializeField]
    private float brakeEffectiveness;
    [SerializeField]
    private float brakeForce; //Force being applied to RB as it heads backwards
    private Vector3 brakeDir; //Holds the data for the direction the RB would push towards on brake

    //Force being added to the rb
    private Vector3 movement;



    void Start()
    {
        speedCap = 95f; //speed will be 1:1 in comparison to MPH
        snowmobileRB = gameObject.GetComponent<Rigidbody>(); //Gets the rb
    }

    void Update()
    {

        //Increase acceleration when drive axis is increased, caps it out if it's too high
        if(Input.GetAxis("Drive") > 0f)
        {
            if (acceleration < 1f)
            {
                acceleration = 1f;
            }
            else if(acceleration <= accelCap)
            {
                acceleration += accelIncrease * Time.deltaTime;
            }
            else
            {
                acceleration = accelCap;
            }
        }else if(Input.GetAxis("Drive") < 0f) //Handles the logic for breaking if the player hits the "backwards" button
        {
            if(acceleration > 0f)
            {
                acceleration = 0f;
            }
            if(speed > 0f)
            {
                brakeDir = (transform.forward * -1 * brakeForce);
                snowmobileRB.AddForce(brakeDir);
                speed -= brakeEffectiveness * Time.deltaTime;
            }
        }

        //Slows the snowmobile speed down when the player is not accelerating
        if (speed > 0f)
        {
            speed -= speedDecay * Time.deltaTime;
        }
        else if (speed < 0f)
        {
            speed = 0f;
        }

        //VERY unlikely to be used unless user is being very unsafe. might remove
        if(speed > speedCap)
        {
            speed = speedCap;
        }

        speed += acceleration * Time.deltaTime * accelModifier;

        //Moves the snowmobile forward based on the current speed
        movement = (transform.forward * (speed)) / speedModifier;
        snowmobileRB.AddForce(movement);
    }
}
