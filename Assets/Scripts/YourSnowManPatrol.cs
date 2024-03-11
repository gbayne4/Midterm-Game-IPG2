using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YourSnowManPatrol : MonoBehaviour
{

    [SerializeField]
    private float height;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int distance;

    NavMeshAgent agent;

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destination;
    private bool walkPoint;

    [SerializeField]
    private float rangeNeg;

    [SerializeField]
    private float rangePos;

    [SerializeField]
    private float almostThere;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        { Patrol(); }

        if (agent.speed == 0) walkPoint = false; //me trying to fix the issue of some of my fish not swimming 
    }


    void Patrol()
    {
        //have it first pick a location
        if (!walkPoint) SearchForDest();

        //if walkpoint is in a viable location, it will walk towards thta direction
        if (walkPoint) agent.SetDestination(destination);

        //once it gets close to the end, changes destination
        if (Vector3.Distance(transform.position, destination) < almostThere) walkPoint = false;
    }

    void SearchForDest()
    {
        //sets a random location
        float x = Random.Range(-rangeNeg, rangePos);
        float z = Random.Range(-rangeNeg, rangePos);


        //gives it a new location to patrol / swim to
        destination = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        //keeps snowman from going off the map
        if (Physics.Raycast(destination, Vector3.down, groundLayer))
        {
            walkPoint = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if you accidentally hit your snowman
        if ((collision.gameObject.tag == "FireBox") && (!CheckGasLevel.noGas)) //if we collide with a game object whose tag is equal to firebox
        {
            Debug.Log("hit man");
            HitSnowman();

        }

    }
    void HitSnowman()
    {
        //you can destroy your snowman and lose points 
        if (Input.GetKey(KeyCode.E))

        {
            ScoreCalculator.score -= 150;
            Destroy(gameObject);
        }
    }
}

