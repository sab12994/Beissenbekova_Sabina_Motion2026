using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed;
    public float accelerationTIme;
    float acceleration;

    public SpriteRenderer player;
    public LayerMask layerMask;

    public float friction;

    float gravity;
    public float apexHeight;
    public float apexTIme;
    float initialJumpVelocity;

    public float terminalSpeed;

    public float coyoteTime;


    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTIme;


        gravity = -2f * apexHeight / (apexTIme * apexTIme);
        initialJumpVelocity = 2f * apexHeight / apexTIme;

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
            //player.flipX = false;


        }
        if (Keyboard.current.dKey.isPressed)
        {
            playerInput.x += 1f;
        }

        MovementUpdate(playerInput);


        //if (GetFacingDirection() == FacingDirection.left)
        //{
        //    player.flipX = true;
        //}
        //if (GetFacingDirection() == FacingDirection.right)
        //{
        //    player.flipX = false;
        //}



        //if(IsGrounded() == true)
        //{
            
        //}
        

    }

    private void MovementUpdate(Vector2 playerInput)
    {

        Vector2 newVelocity = rb.linearVelocity;

        newVelocity.y += gravity * Time.deltaTime;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded() == true)
        {          
            newVelocity.y = initialJumpVelocity;

            coyoteTime = 0f; //sets the timer to 0 to start counting up again

        }

        if (playerInput.x != 0f)
        {
            //accelerate
            newVelocity += playerInput * acceleration * Time.deltaTime;
           
        } else
        {
            //something
            
        }

        if (newVelocity.y < -terminalSpeed) // if new velocity is negative it means the player is falling down
        {
            newVelocity.y = -terminalSpeed; // sets the deceleration speed to be the same
        }

        rb.linearVelocity = newVelocity;
               

    }

    public bool IsWalking()
    {        
        if (rb.linearVelocity.x < - 0.01f)
        {
            return true;
        }
        if (rb.linearVelocity.x > 0.01f)
        {
            return true;
        }
        return false;
    }

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(player.transform.position, -player.transform.up, 1f, layerMask))
        {            
            return true;            
        }
        else
        {            
            if (coyoteTime <= 1f) //timer for the double jumping 
            {
                coyoteTime += Time.deltaTime;
                return true;
            }
            return false;
        }  
    }

    public FacingDirection GetFacingDirection()
    {
        if (rb.linearVelocity.x < - 0.01f)
        {
            return FacingDirection.left;
        } 
        if (rb.linearVelocity.x > 0.01f)
        {
            return FacingDirection.right;
        }

        if (player.flipX == true)
        {
            return FacingDirection.left;
        } 
        else
        {
            return FacingDirection.right;
        }        

    }
}
