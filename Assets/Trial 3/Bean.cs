using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    [SerializeField] Vector3 jumpHeight;
    [SerializeField] float moveSpeed;
    [SerializeField] float dashBoost;
    //[SerializeField] float cameraSensitivity;
    [SerializeField] private Transform plungeCheckTransform = null;

    private Rigidbody rigidBodyComponent;
    [SerializeField] private float movementForwardBackward;
    [SerializeField] private float movementLeftRight;
    //[SerializeField] private float cameraMovementUpDown;
    //[SerializeField] private float cameraMovementLeftRight;

    private bool pressedJump;
    private bool pressedDash;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressedJump = true;
            Debug.Log("JUMP");
        }
        movementForwardBackward = Input.GetAxis("Vertical");
        movementLeftRight = Input.GetAxis("Horizontal");
        //cameraMovementLeftRight = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        if (pressedJump)
        {
            rigidBodyComponent.AddForce(jumpHeight, ForceMode.VelocityChange);
            pressedJump = false;
        }
        rigidBodyComponent.velocity = new Vector3(movementLeftRight * moveSpeed, rigidBodyComponent.velocity.y, movementForwardBackward * moveSpeed);
        //transform.eulerAngles += new Vector3(0,cameraMovementLeftRight * cameraSensitivity,0);
    }
}
