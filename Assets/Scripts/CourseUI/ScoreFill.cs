using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFill : MonoBehaviour
{
    public Image ScoreImage;

    // Start is called before the first frame update
    void Start()
    {
        //Score starts full
        ScoreImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Score goes down by 10%
        //ScoreImage.fillAmount -= 0.1;
    }
}
