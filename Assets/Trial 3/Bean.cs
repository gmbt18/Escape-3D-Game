using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bean : MonoBehaviour
{
    [SerializeField] Vector3 jumpHeight;
    [SerializeField] float moveSpeed;
    [SerializeField] float dashBoost;
    [SerializeField] private Transform groundCheck;

    private Rigidbody rigidBodyComponent;
    [SerializeField] private float movementForwardBackward;
    [SerializeField] private float movementLeftRight;

    private bool pressedJump;
    private bool hasJump;

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
    }

    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(movementLeftRight * moveSpeed, rigidBodyComponent.velocity.y, movementForwardBackward * moveSpeed);

        if (pressedJump && hasJump)
        {
            rigidBodyComponent.AddForce(jumpHeight, ForceMode.VelocityChange);
            pressedJump = false;
            hasJump = false;
        }

        if (Physics.OverlapSphere(groundCheck.position, 0.1f).Length > 1)
        {
            hasJump = true;
            return;
        }
    }
}
