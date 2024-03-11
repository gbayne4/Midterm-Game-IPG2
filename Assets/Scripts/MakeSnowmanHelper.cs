using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MakeSnowmanHelper : MonoBehaviour
{
    public static int hatsCollected = 0;
    private bool craft = false;
    public GameObject mySnowman; //create new snowman
    [SerializeField]
    ParticleSystem part;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BuildSnowman();
    }

    private void OnCollisionEnter(Collision collision)
    {

        //if you hit an obstacle
        if (collision.gameObject.tag == "Hat") //if we collide with a game object whose tag is equal to player
        {
            //you can make as many snowman as you have hats 
            hatsCollected++;
            ScoreCalculator.score += 50;
            Debug.Log("Collected Hat");
            //tell user they collected the hat
            MessageSender.displayMessage = true;
            Destroy(collision.gameObject); //destroy displayed hat 
        }

        if (collision.gameObject.tag == "WorkBench") //if we collide with a game object whose tag is equal to player
        {
            //you can make as many snowman as you have hats 
            craft = true;
            Debug.Log("at bench");
        }
        else
        {
            craft = false;
        }
    }

    void BuildSnowman()
    {
        //if you have a hat and youre at the bench and press R, you can make a snowman
        if ((hatsCollected >= 1) && (craft) && (Input.GetKey(KeyCode.R)))
        {
            ScoreCalculator.score += 150;
            hatsCollected--;
            part.Play();
            Instantiate(mySnowman, new Vector3(78.6f, 10.14f, 32.53f), Quaternion.identity); //spawns snowman on crafting table
            Debug.Log("Crafting"); 
        }
    }
}
