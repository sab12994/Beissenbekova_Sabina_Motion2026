using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();

    }

    void DrawConstellation()
    {
        //Vector2 start = new Vector2(0, 0);
        //Vector2 testpoint = new Vector2(15, 15) * Time.deltaTime * drawingTime;

        //Debug.DrawLine(start, testpoint, Color.red, 20);


        for (int i = 0; i < starTransforms.Count - 1; i ++)
        {
            Vector2 start = starTransforms[i].position;
            Vector2 end = starTransforms[i + 1].position * drawingTime;

            Debug.DrawLine(start, end, Color.red, 20);
        }

    }
}
