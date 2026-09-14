using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        DrawSquare(currentMousePos, 5f, Color.red, 0.5f);
    }

    public static Vector2 GetNormalized(Vector2 vector)
    {
        float sizeOfVector = GetMagnitude(vector);

        //Gives us a vector that has a size of 1 that has the same direction as before
        Vector2 normalizedVector = new Vector2(vector.x, vector.y) / sizeOfVector;
        return normalizedVector;
    }

    public static float GetMagnitude(Vector2 vector) 
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    public static void DrawSquare(Vector2 centerPoint, float size, Color color, float duration)
    {
        //top line
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, color, duration);

        //left line
        startPoint = centerPoint + new Vector2(-size, size);
        endPoint = centerPoint + new Vector2(-size, -size);

        Debug.DrawLine(startPoint, endPoint, color, duration);

        //bottom line
        startPoint = centerPoint + new Vector2(-size, -size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, color, duration);

        //bottom line
        startPoint = centerPoint + new Vector2(size, -size);
        endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, color, duration);

    }


}
