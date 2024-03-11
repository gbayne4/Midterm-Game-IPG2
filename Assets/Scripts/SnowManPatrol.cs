using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SnowManPatrol : MonoBehaviour
{
    private GameObject player;

    private bool hitIgloo = false;
   
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
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        //player = GameManager.instance.player; did not work for whatever reason
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();

        //Debug.Log(player.transform.position);

        if (agent.speed == 0) walkPoint = false; //me trying to fix the issue of some of my fish not swimming 

        if (!hitIgloo) //only works if not hitting the igloo
        {
            //once the player gets close enough to the snowman, starts chasing 
            if ((Vector3.Distance(player.transform.position, this.transform.position) < distance) && (player.transform.position.y < this.transform.position.y + height))
            {
                //moves towards player
                //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * speed);

                agent.SetDestination(player.transform.position);
                transform.LookAt(player.transform.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
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

        //keep the snowman from following if it hit the igloo
        if (collision.gameObject.tag == "Igloo")
        {
            hitIgloo = true;
            Debug.Log("igloo!");
        }
        else
        {
            hitIgloo = false;
        }

    }
}
