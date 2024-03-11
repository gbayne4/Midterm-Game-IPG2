using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class FindOtherSnowmen : MonoBehaviour
{
    public GameObject snowman;
    [SerializeField]
    private int speed;

    private int timer = 0;
    private bool startNav = false;

    NavMeshAgent snowmanNav;
    // Start is called before the first frame update
    void Start()
    {
        snowmanNav = GetComponent<NavMeshAgent>();
        snowmanNav.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (!startNav)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(78.60222f, 2.6f, -25.71f), Time.deltaTime * speed);
        }
        else
        {
            FindSnowman();
        }

    }

    void Timer()
    {
        timer++;

        if (timer > 5000)
        {
            timer = 0;
            startNav = true;
        }
    }

    void FindSnowman()
    {
        snowmanNav.enabled = true;
       // transform.position = Vector3.MoveTowards(transform.position, snowman.transform.position, Time.fixedDeltaTime * speed);
       // snowmanNav.SetDestination(snowman.transform.position);
       // transform.LookAt(snowman.transform.position);
       // transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "snowman") //if we collide with a game object whose tag is equal to firebox
        {
            //they can kill the other snowmen
            Destroy(collision.gameObject);
            ScoreCalculator.score += 100;

        }
    }
}
