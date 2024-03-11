using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class CollisionManager : MonoBehaviour
{
    private int snowmanHealth = 15;
    public GameObject hat;
    public GameObject snowman;
    void Update()
    {
        if (snowmanHealth <= 0 )
        {
            ScoreCalculator.score += 200;
            Instantiate(hat, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            //anytime you destroy a snowman, two more form
            //spawn in the sky so they don't get stuck in the obstacles
            Instantiate(snowman, new Vector3(Random.Range(-150,150), 48.4f, Random.Range(-150, 150)), Quaternion.identity);
            Instantiate(snowman, new Vector3(Random.Range(-150, 150), 48.4f, Random.Range(-150, 150)), Quaternion.identity);

            Debug.Log("Snowman Dead");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if you hit an obstacle
        if (collision.gameObject.tag == "Player") //if we collide with a game object whose tag is equal to player
        {
            // Debug.Log("I hit the man");
            HealthManager.playerHealth -= 1;
            //Debug.Log(HealthManager.playerHealth);
        }

        if ((collision.gameObject.tag == "FireBox") && (!CheckGasLevel.noGas)) //if we collide with a game object whose tag is equal to firebox
        {
            HitSnowman();

        }

    }
    void HitSnowman()
    {
        if (Input.GetKey(KeyCode.E))
            
        {
            snowmanHealth--;
            ScoreCalculator.score += 5;
            //Debug.Log("I hit the snowman"); 
        }
    }
}
