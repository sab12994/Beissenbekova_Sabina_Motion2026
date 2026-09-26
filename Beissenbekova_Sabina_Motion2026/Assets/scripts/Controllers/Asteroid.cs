using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    //public void AsteroidMovement()
    //{
    //    Vector3 moveVelocity = new Vector3 moveVelocity.normalized * moveSpeed;


    //    for (int i = 0; i < inAsteroids.Count; i++)
    //    {
            
    //        Transform asteroidPos = inAsteroids[i];

    //        //Vector3 end = new Vector3(asteroidPos.position.x, asteroidPos.position.y);

    //        maxFloatDistance = Random.Range(asteroidPos.position.x - 5f, asteroidPos.position.y + 5f);           

    //    }

    //    transform.position = (asteroidPos.position * maxFloatDistance) + moveVelocity * Time.deltaTime;

    //}


}
