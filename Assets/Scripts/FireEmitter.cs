using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEmitter : MonoBehaviour
{
    [SerializeField]
    ParticleSystem part;

    void Start()
    {


    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.E)) && (!CheckGasLevel.noGas))
        {
            //Debug.Log("E pressed");
            part.Play();
        }

    }
}
    /* tried using a particle collision, this failed
    void OnParticleCollision(GameObject other)
    {
        if (other == snowman)
        {
            Debug.Log("hitSnowman");
        }

        if (other.tag == "Player")
        { Debug.Log(other.tag); }

    }
    */





