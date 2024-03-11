using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScoreCalculator.score = 0;
        HealthManager.playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
