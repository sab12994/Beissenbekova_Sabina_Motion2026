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
    public float inBombSpacing;
    public int inNumberOfBombs;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(bombOffSet);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(inBombSpacing, inNumberOfBombs);
        }
    }


    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 spawnPos = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPos, Quaternion.identity); 
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        Vector3 distance = transform.position - bombPrefab.transform.position;
        
        if (distance.magnitude > 3)
        {
            Vector3 theMiddle = distance.normalized * (distance.magnitude/2);
            Instantiate(bombPrefab, theMiddle, Quaternion.identity);

        }
    }

    //public void WarpPlayer(Transform target)
    //{
        
    //}
}
