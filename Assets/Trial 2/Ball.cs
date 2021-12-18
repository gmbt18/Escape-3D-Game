using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 jumpForce;

    private float movementForwardBackward;
    private float movementLeftRight;
    private Rigidbody rigidBodyComponent;

    private int noOfJumps;
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
            hasJump = true;
            Debug.Log("JUMP");
        }
        movementForwardBackward = Input.GetAxis("Vertical") * moveSpeed;
        movementLeftRight = Input.GetAxis("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(movementLeftRight, rigidBodyComponent.velocity.y, movementForwardBackward);

        if (hasJump && noOfJumps > 0)
        {
            rigidBodyComponent.AddForce(jumpForce, ForceMode.VelocityChange);
            hasJump = false;
            noOfJumps -= 1;
        }

        if (Physics.OverlapSphere(groundCheck.position, 0.1f).Length > 1){
            noOfJumps = 1;
            return;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }
    }
}
