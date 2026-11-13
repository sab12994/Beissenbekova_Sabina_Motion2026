using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;

    public Transform rat1;
    public Transform rat2;

    //public float forceStrength;

    //public bool GetIgnoreCollision(rb.GetComponent<BoxCollider2D>(), rb3.GetComponent<BoxCollider2D>());   couldn't figure out how to use this function

    public bool ignore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), rb3.GetComponent<BoxCollider2D>(), ignore); //makes these two coliders ignore each other and pass through each other
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

        rb2.AddTorque(1f, ForceMode2D.Force); //rotates the object with a stated force aroind its internal axis
        
        //if(Physics2D.Linecast(rat1.position, rat2.position))
        //{
        //    Debug.Log("somone passed through two rats!"); //if an object passes through between rat1 and rat2 this message should appear in the console. FOr some reason, it triggers all the time
        //}
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
