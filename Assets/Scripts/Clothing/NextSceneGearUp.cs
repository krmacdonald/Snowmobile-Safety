using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneGearUp : MonoBehaviour
{
    public string SceneName;
    public ClothingManager clothes;
    public GameObject nextButton;

    public void revealButton()
    {
        bool canProceed = true;
        for (int i = 0; i < 4; i++)
        {
            if (clothes.correctClothes[i] == false)
            {
                canProceed = false;
            }
        }
        if (canProceed)
        {
            nextButton.SetActive(true);
        }
    }

    public void SceneSwitch()
    {
        //Creates bool
        bool canProceed = true;
        for (int i = 0; i < 4; i++)
        {
            if (clothes.correctClothes[i] == false)
            {
                canProceed = false;
            }
        }
        if (canProceed)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
