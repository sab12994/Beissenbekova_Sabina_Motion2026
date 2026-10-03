using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 1;    
    public GameObject enemysBomb;
    private void Update()
    {
        EnemyMovement();
        BombSpawn();
    }

    public void EnemyMovement()
    {
        Vector2 playerPos = playerTransform.position;
        Vector2 direction = playerPos - (Vector2)transform.position;
        transform.up = direction;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        
        //transform.position += transform.up;

    }

    public void BombSpawn()
    {        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(enemysBomb, transform.up, Quaternion.identity);
        }
    }


}
