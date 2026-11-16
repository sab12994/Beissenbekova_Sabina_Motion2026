using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed;
    public float accelerationTIme;
    float acceleration;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTIme;
    }

    // Update is called once per frame
    void Update()
    {
        
        //The input from the player needs to be determined and then passed in the to the MovementUpdate which should
        //manage the actual movement of the character.
        Vector2 playerInput = new Vector2();
        

        if (Keyboard.current.aKey.isPressed)
        {
            playerInput.x -= 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            playerInput.x += 1f;
        }

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        Vector2 newVelocity = rb.linearVelocity;

        if (playerInput.x != 0f)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
        } else
        {
            //?
        }
        rb.linearVelocity = newVelocity;
    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return true;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
