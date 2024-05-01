using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreFill : MonoBehaviour
{
    public Image ScoreImage;
    public TMP_Text scoreText;
    public float score = 55;

    // Start is called before the first frame update
    void Start()
    {
        //Score starts full
        ScoreImage.fillAmount = score/100;
        scoreText.text = string.Concat("Score: ", score.ToString(), "%");
    }

    public void decreaseScore(float amount)
    {
        score -= amount;
        ScoreImage.fillAmount = score / 100;
        scoreText.text = string.Concat("Score: ", score.ToString(), "%");
    }

    public void increaseScore(float amount)
    {
        score += amount;
        ScoreImage.fillAmount = score / 100;
        scoreText.text = string.Concat("Score: ", score.ToString(), "%");
    }
}
