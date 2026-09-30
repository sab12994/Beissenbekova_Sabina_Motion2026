using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 bombOffSet;
    //public float inBombSpacing;
    //public int inNumberOfBombs;

    public float inDistance;

    public float ratio;

    float inMaxRange;

    public Vector3 currentVelocity;

    public float maxSpeed;
    public float accelerationTime;
    public float currentAcceleration;

    public float decelerationTime;
    float deceleration;

    public List<float> degrees;
    private int currentAngleIndex = 0;

    public float circleRadius;
    public Vector3 circleOffset;

    //public float shiftDuration;
    //public float shiftProgress = 0f;

    //List<Vector2> points;


    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime; 
        deceleration = maxSpeed / decelerationTime;


        //float fortyFiveDegrees = 45f;
        //float ffDInRadians = fortyFiveDegrees * Mathf.Deg2Rad;

        //float twoPiRadians = 2 * Mathf.PI;
        //float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        ////for these functions its better to use radians instead of degrees
        //Mathf.Cos(fortyFiveDegrees * Mathf.Deg2Rad);
        //Mathf.Sin(fortyFiveDegrees * Mathf.Deg2Rad);
    }

    void Update()
    {

        PlayerMovement();

        CircleExercise();

        PlayerRadar();
       
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(bombOffSet);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail();
        }

        //if (Keyboard.current.aKey.isPressed)
        //{ 
        //    WarpPlayer(enemyTransform, ratio);
        //}

        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    DetectAsteroids(inMaxRange, asteroidTransforms);
        //}
    }


    public void EnemyRadar()
    {
        float angle45 = 45f * Mathf.Deg2Rad;
        float angle45X = Mathf.Cos(angle45);
        float angle45Y = Mathf.Sin(angle45);
        Vector2 angle45Point = new Vector2 (angle45X, angle45Y);

        float angle135 = 135f * Mathf.Deg2Rad;
        float angle135X = Mathf.Cos(angle135);
        float angle135Y = Mathf.Sin(angle135);
        Vector2 angle135Point = new Vector2(angle135X, angle135Y);

        float angle225 = 225f * Mathf.Deg2Rad;
        float angle225X = Mathf.Cos(angle225);
        float angle225Y = Mathf.Sin(angle225);
        Vector2 angle225Point = new Vector2(angle225X, angle225Y);

        float angle315 = 315f * Mathf.Deg2Rad;
        float angle315X = Mathf.Cos(angle315);
        float angle315Y = Mathf.Sin(angle315);
        Vector2 angle315Point = new Vector2(angle315X, angle315Y);


        Vector3 center = transform.position;
        Vector2 p1 = new Vector2(center.x + 1f, center.y);
        Vector2 p2 = new Vector2(center.x, center.y - 1f);
        Vector2 p3 = new Vector2(center.x - 1f, center.y);
        Vector2 p4 = new Vector2(center.x, center.y + 1f);

        Color color = Color.green;

        float distance = Vector3.Distance(center, enemyTransform.position);

        if (distance <= 1f)
        {
            color = Color.red;
        }

        Debug.DrawLine(p1, angle315Point, color, 50f);
        Debug.DrawLine(angle315Point, p2, color, 50f);
        Debug.DrawLine(p2, angle225Point, color, 50f);
        Debug.DrawLine(angle225Point, p3, color, 50f);
        Debug.DrawLine(p3, angle135Point, color, 50f);
        Debug.DrawLine(angle135Point, p4, color, 50f);
        Debug.DrawLine(p4, angle45Point, color, 50f);
        Debug.DrawLine(angle45Point, p1, color, 50f);

        




        //for (int i = 0;  i < points.Count; i++)
        //{

        //}


    }
        
    public void CircleExercise()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            currentAngleIndex++;

            if (currentAngleIndex >= degrees.Count)
            {
                currentAngleIndex = 0;
            }
        }


        float currentAngle = degrees[currentAngleIndex];
        float currentAngleInRadians = currentAngle * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero;
        float endPointX = Mathf.Cos(currentAngleInRadians);
        float endPointY = Mathf.Sin(currentAngleInRadians);
        Vector3 endPoint = new Vector3(endPointX, endPointY) * circleRadius + circleOffset;

        Debug.DrawLine(startPoint, endPoint, Color.wheat);



        //Vector2 origin = Vector2.zero;


        //for(int i = 0; i < degrees.Count;  i++)
        //{
        //    float x = 0;
        //    degrees[i] = x + 30f;
        //    degrees[i] = x;

        //    Debug.Log("");

        //    if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //    {
        //        degrees[i] = degrees[i + 1];
        //        Debug.Log("");
        //    }


        //}
    }


    public void PlayerMovement()
    {
        //currentVelocity = Vector3.zero;
        Vector3 accelerationDirection = Vector3.zero;

        if (Keyboard.current.aKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }

        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }


        if(!Keyboard.current.aKey.isPressed && !Keyboard.current.wKey.isPressed && !Keyboard.current.sKey.isPressed && !Keyboard.current.dKey.isPressed)
        {
            currentVelocity -= currentVelocity.normalized * deceleration * Time.deltaTime;
        }


        transform.position = transform.position + currentVelocity * Time.deltaTime;


        //if (currentVelocity = 0.00001f)
        //{
        //    currentVelocity = currentVelocity * 0f;
        //}

    }

   
    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 test = new Vector2(0,0);


        for (int i = 0; i < inAsteroids.Count; i++)
        {
            Transform asteroidPos = inAsteroids[i];

            Vector3 end = new Vector3(asteroidPos.position.x, asteroidPos.position.y);

            Debug.DrawLine(playerPos, end, Color.green, 2.5f);

        }


        //float dis = Vector3.Distance(playerPos, inAsteroids.position);

        //Debug.DrawLine(playerPos, test, Color.green, 2.5f);

    }

   
    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPos = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPos, Quaternion.identity); 
    }

    public void SpawnBombTrail()
    {
        Vector3 distance = transform.position - bombPrefab.transform.position;
        
        if (distance.magnitude > 3)
        {
            Vector3 theMiddle = distance.normalized * (distance.magnitude/2);
            Instantiate(bombPrefab, theMiddle, Quaternion.identity);

        }
    }

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        float random = Random.Range(0, 4);
        Vector3 spawnPos = transform.position * random;

        if (random == 0)
        {            
            spawnPos = transform.position + new Vector3 (0, inDistance, 0);
        }
        if(random == 1)
        {
            spawnPos = transform.position - new Vector3(0, inDistance, 0);
        }
        if(random == 2)
        {
            spawnPos = transform.position + new Vector3(inDistance, 0, 0);
        }
        if(random == 3)
        {
            spawnPos = transform.position - new Vector3(inDistance, 0, 0);
        }
                      

        Instantiate(bombPrefab, spawnPos, Quaternion.identity);

    }

    public void WarpPlayer(Transform target, float ratio)
    {
        ratio += Time.deltaTime;
        
        if(ratio > 0)
        {
            ratio = 0;
        }

        transform.position = Vector2.Lerp(target.position, transform.position, ratio);
    }

}
