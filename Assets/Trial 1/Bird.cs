using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Vector3 jumpForce;
    public Vector3 leftForce;
    public Vector3 rightForce;
    public Vector3 speed;
    bool hasJump = false;
    bool goRight = false;
    bool goLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            hasJump = true;
            Debug.Log("JUMP");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            goLeft = true;
            Debug.Log("LEFT");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            goRight = true;
            Debug.Log("RIGHT");
        }
    }

    void FixedUpdate()
    {
        Vector3 total = new Vector3(0f, 0f, 0f);
        if (hasJump)
        {
            //transform.position += jumpForce;
            GetComponent<Rigidbody>().AddForce(jumpForce,ForceMode.VelocityChange);
            hasJump = false;
        } else if (goRight){
            transform.position += rightForce;
            goRight = false;
        } else if (goLeft)
        {
            transform.position += leftForce;
            goLeft = false;
        }
        transform.position += speed + total;
    }
}
