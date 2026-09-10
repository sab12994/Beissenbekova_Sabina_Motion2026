using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public Vector2 L;
    public Vector2 D;
    public Vector2 R;
    public Vector2 B;

    //public GameObject mouse;

    //float x;
    //float y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //transform.position = mousePos;
        //mouse.x = x;
        //mouse.y = y;

        //Vector2 B = new Vector2(x - 1, -1);
        //Vector2 L = new Vector2(x - 1, y + 1);
        //Vector2 D = new Vector2(x + 1, y + 1);
        //Vector2 R = new Vector2(x + 1, y - 1);

        Vector2 B = new Vector2(- 1, -1);
        Vector2 L = new Vector2(- 1, 1);
        Vector2 D = new Vector2(1, 1);
        Vector2 R = new Vector2(1, - 1);

        Debug.DrawLine(B, L, Color.white, 50);
        Debug.DrawLine(L, D, Color.white, 50);
        Debug.DrawLine(D, R, Color.white, 50);
        Debug.DrawLine(R, B, Color.white, 50);
    }
}
