using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressFill : MonoBehaviour
{
    public Image BarFill;
    public string SceneName;
    public GameObject Fence1;
    public GameObject Fence2;

    // Start is called before the first frame update
    void Start()
    {
        //Progress bar begins empty
        BarFill.fillAmount = 0f;

        Fence2.SetActive(false);
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

        //Scene Change to score screen if progress bar is full
        if(BarFill.fillAmount == 1f){
            SceneManager.LoadScene(SceneName);
        }

        //Fences change places halfway to guide the player through the course
        if(BarFill.fillAmount == 0.5f){
            Fence1.SetActive(false);
            Fence2.SetActive(true);
        }

        Destroy(gameObject);   
        
    }
}
