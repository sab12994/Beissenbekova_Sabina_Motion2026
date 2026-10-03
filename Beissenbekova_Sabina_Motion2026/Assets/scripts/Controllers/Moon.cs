using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public List<float> degrees;
    int angleIndex = 0;
    public float radius;
    public float speed;

    float shiftProgress = 0f;
    float shiftDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    angleIndex++;

        //    if (angleIndex >= degrees.Count)
        //    {
        //        angleIndex = 0;
        //    }
        //}

        shiftProgress += speed * Time.deltaTime;
        

        if (shiftProgress > shiftDuration)
        {
            angleIndex++;

            if (angleIndex >= degrees.Count)
            {
                angleIndex = 0;
            }
            shiftProgress = 0f;
        }

        float angles = degrees[angleIndex];
        float anglesInRad = angles * Mathf.Deg2Rad;

        float posX = target.position.x + Mathf.Cos(anglesInRad) * radius;
        float posY = target.position.y + Mathf.Sin(anglesInRad) * radius;

        Vector2 targetsPos = new Vector2(posX, posY);
        transform.position = targetsPos;
                
    }
}
