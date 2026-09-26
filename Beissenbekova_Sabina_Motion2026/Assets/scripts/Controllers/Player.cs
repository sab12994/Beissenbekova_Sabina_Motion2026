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

    
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime; 
        deceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {

        PlayerMovement();


        
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

        if (Mouse.current.leftButton.isPressed)
        {
            DetectAsteroids(inMaxRange, asteroidTransforms);
        }
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
