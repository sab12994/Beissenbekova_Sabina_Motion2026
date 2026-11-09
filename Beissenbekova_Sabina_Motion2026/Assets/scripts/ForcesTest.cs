using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceStrength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //    mousePos.z = 0;

        //    Vector3 directionToApplyForce = mousePos - transform.position;

        //    rb.AddForce(directionToApplyForce.normalized * forceStrength, ForceMode2D.Force);
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Colision enter");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Colision enter");
    }
}
