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

    void Update()
    {             

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(bombOffSet);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail();
        }
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

    //public void WarpPlayer(Transform target)
    //{

    //}
}
