using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageSender : MonoBehaviour
{
    TextMeshProUGUI thisMessage;

    private int timer;
    public static bool displayMessage = false;
    // Start is called before the first frame update
    void Start()
    {
        thisMessage = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        thisMessage.text = "";

        if (displayMessage)
        {
            MessageTimer();
            thisMessage.text = "Hat Collected";
        }
    }
    void MessageTimer()
    {
        timer++;

        if (timer > 1000)
        {
            timer = 0;
            displayMessage = false;
        }
    }
}
