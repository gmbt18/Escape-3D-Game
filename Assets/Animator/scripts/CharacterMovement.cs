using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;

    Animator animator;
    
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 playerVelocity;
    bool isMovementPressed;
    bool isJumpPressed = false;
    bool grounded;
    float rotationFactorPerFrame = 15.0f;
    float jumpH = 18.0f;
    float grav = -9.81f;
    float speed;

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.Controls.Move.started += onMovementInput;
        playerInput.Controls.Move.canceled += onMovementInput;
        playerInput.Controls.Move.performed += onMovementInput;
        playerInput.Controls.Jump.started += onJump;
        playerInput.Controls.Jump.canceled += onJump;
        
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }


    }

    void onJump (InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();

    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * 8.0f;
        currentMovement.z = currentMovementInput.y * 8.0f;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void MovementJump(){
        grounded = characterController.isGrounded;

        if(grounded){
            playerVelocity.y=0.0f;
        }

        if(isJumpPressed && grounded){
            playerVelocity.y += Mathf.Sqrt(jumpH * -1.0f * grav);
            isJumpPressed = false;
        }
        playerVelocity.y += grav * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    void handleAnimation()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isJumping = animator.GetBool("isJumping");

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else if(!isMovementPressed && isRunning)
        {
            animator.SetBool("isRunning", false);
        }

        if (isJumpPressed && !isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else if(!isJumpPressed && isJumping && !grounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        handleAnimation();
        MovementJump();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    void OnEnable()
    {
        playerInput.Controls.Enable();
    }

    void OnDisable()
    {
        playerInput.Controls.Disable();
    }


}
