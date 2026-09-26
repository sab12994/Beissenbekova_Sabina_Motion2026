using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector2 playerPos = playerTransform.position;
        Vector2 direction = playerPos - (Vector2)transform.position;
        transform.up = direction;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        
        //transform.position += transform.up;

    }


}
