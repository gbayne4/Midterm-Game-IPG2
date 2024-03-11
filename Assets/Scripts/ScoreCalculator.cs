using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = Mathf.RoundToInt(score).ToString("0000");
    }
}
