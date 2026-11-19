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
    public bool isgrounded;
    public LayerMask layerMask;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = maxSpeed / accelerationTIme;
        isgrounded = false;
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

        
        if (Physics.Raycast(player.transform.position, - player.transform.up, 1f, layerMask) == false)
        {
            IsGrounded();
            isgrounded = true;
        }
        
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
        if (rb.linearVelocity.x < 0f)
        {
            return FacingDirection.left;
        } 
        if (rb.linearVelocity.x > 0f)
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
