using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreEndDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreThisRound;
    TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetInt("highscore", 0);
        scoreThisRound = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        highscore = transform.GetChild(3).GetComponent<TextMeshProUGUI>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreCalculator.score > PlayerPrefs.GetInt("highscore"))
            {
            PlayerPrefs.SetInt("highscore", ScoreCalculator.score);
        }

        scoreThisRound.text = Mathf.RoundToInt(ScoreCalculator.score).ToString("0000");
        highscore.text = PlayerPrefs.GetInt("highscore").ToString("0000");
    }
}
