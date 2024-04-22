using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressFill : MonoBehaviour
{
    public Image BarFill;

    // Start is called before the first frame update
    void Start()
    {
        //Progress bar begins empty
        BarFill.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       //ProgressScript ps = other.gameobject.GetComponent<ProgressScript>();

        //Adds 0.1 to progress bar each time it hits a checkpoint, the max is 1
        BarFill.fillAmount += 0.1f;
    }
}
