using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

//I attempted adding in a struct, I hope I did it correctly.
public struct PlayerInfo //stored my players info in a struct
{
    public float speed;
    public float drag;
    public float jump;

    public PlayerInfo(float s, float d, float j)
    {
        speed = s;
        drag = d;
        jump = j;
    }
}



public class PlayPlayer : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float mouseSensitivity;

    PlayerInfo thisplayer;

    Transform cameraTrans;
    float cameraPitch = 0;
    float gravityValue = Physics.gravity.x;

    void Start()
    {
        thisplayer = new PlayerInfo(300, 15, 2000);

        rb = gameObject.GetComponent<Rigidbody>();
        rb.drag = thisplayer.drag;

     
        cameraTrans = Camera.main.transform;

        //locking in the center + hiding
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            //Code for looking around



            //beautiful, I struggled trying to make something like this in my previous games
            transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);

            cameraPitch -= mouseDelta.y * mouseSensitivity;
            //prevents a full rotation
            cameraPitch = Mathf.Clamp(cameraPitch, -98, 90);
            cameraTrans.localEulerAngles = Vector3.right * cameraPitch;



            //Code for moving character 

            if (Input.GetKey(KeyCode.W))//going forward
            {
           // Debug.Log("Go forward");
            rb.AddForce(transform.forward * thisplayer.speed);
            }
            if (Input.GetKey(KeyCode.S)) //going backwards
            {
           // Debug.Log("Go back");
            rb.AddForce(-transform.forward * thisplayer.speed);
            }

            if (Input.GetKey(KeyCode.A))
            {
           // Debug.Log("Go left");
            rb.AddForce(-transform.right * thisplayer.speed);
            }


            if (Input.GetKey(KeyCode.D)) //going right
            {
           // Debug.Log("Go right");  
            rb.AddForce(transform.right * thisplayer.speed);
            }

            /*
            //Code for jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * thisplayer.jump);
            }

            */ // removed jumping
        

    }

}