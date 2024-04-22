using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ToClose : MonoBehaviour
{
    [SerializeField] GameObject Alert;
    



    private void Start()
    {
        Alert.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Player"))
        {
            Alert.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Alert.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Alert.SetActive(false);
        }
    }
}
