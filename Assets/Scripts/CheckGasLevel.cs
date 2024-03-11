using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckGasLevel : MonoBehaviour
{
    [SerializeField]
    private Image gasLevel;
    [SerializeField]
    private float decreaseGas;

    public static bool noGas;

    private float gasLevelNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        gasLevel.GetComponent<Image>();
        gasLevel.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //the image is going to be set equal to how much gas is left
        gasLevel.fillAmount = gasLevelNum;

        gasLevelNum = Mathf.Clamp(gasLevelNum, 0, 1); //clamps the value

        //every time E is pressed, gas levels lower.
        if (Input.GetKey(KeyCode.E))
        {
            GasLevelLower();
        }

        if (gasLevel.fillAmount <= 0) //cant use if there is no gas
        {
            GameOver();
        }
    }

    void GasLevelLower()
    {
        gasLevelNum -= decreaseGas;
    }

    void GameOver()
    {
        SceneManager.LoadScene("EndScene");
    }
}
