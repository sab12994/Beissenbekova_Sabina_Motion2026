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

    void Update()
    {

    }


    public void SpawnBombAtOffset(Vector3 inOffset)
    {

    }

    public void WarpPlayer(Transform target)
    {
        //target = enemyTransform;
        //Vector2 position = new Vector2 (transform.position.x, transform.position.y);

        //Vector2 sizeOfVector = new Vector2(target, position); 

        //check how to make Lerp
    }
}
