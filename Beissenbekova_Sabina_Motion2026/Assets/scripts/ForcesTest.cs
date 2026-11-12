using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
    public float forceStrength = 1f;

    public bool ignore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), rb3.GetComponent<BoxCollider2D>(), ignore);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //    mousePos.z = 0;

        //    Vector3 directionToApplyForce = mousePos - transform.position;

        //    rb.AddForce(directionToApplyForce.normalized * forceStrength, ForceMode2D.Force);
            
        //}

        rb2.AddTorque(1f, ForceMode2D.Force);
        
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Colision exit");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        Debug.Log("Colision stay");
    }
}
