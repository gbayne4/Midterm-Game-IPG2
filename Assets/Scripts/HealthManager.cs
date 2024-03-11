using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static float playerHealth = 100;

    [SerializeField]
    private Image healthBar;

    public float GetHeath
    {
        get
        {
            return playerHealth;
        }

        set
        {
            //clamps the value (wont exceed 0 and 100), then mulitplies it to be used for the health bar
            playerHealth = Mathf.Clamp(playerHealth, 0, 100) * .01f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.GetComponent<Image>();
        healthBar.fillAmount = 1; 


    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        playerHealth += .0001f;
        healthBar.fillAmount = playerHealth * .01f;

        if (playerHealth <= 1) {
            Debug.Log("Game Over");
            GameOver(); }
    }

    void GameOver()
    {
        SceneManager.LoadScene("EndScene");
    }
}
