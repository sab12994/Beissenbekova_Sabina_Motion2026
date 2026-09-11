using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public bool isTheLeftMouseIsPressed = false;
    public bool isTheLeftMouseIsReleased = false;
    Vector2 startOfLine;
    Vector2 endOfLine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTheLeftMouseIsPressed = Mouse.current.leftButton.isPressed;
        isTheLeftMouseIsReleased = Mouse.current.leftButton.wasReleasedThisFrame;


        if (isTheLeftMouseIsPressed == true)
        {
            Debug.Log("The left mouse button is being held down");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            startOfLine = mousePos;
        }
        if (isTheLeftMouseIsReleased == true)
        {
            Debug.Log("The left mouse button is released");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            endOfLine = mousePos;
        }

        Debug.DrawLine(startOfLine, endOfLine, Color.yellow, 50);
    }
}
