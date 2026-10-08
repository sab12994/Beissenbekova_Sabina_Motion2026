using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 1;    
    public GameObject enemysBomb;
    public Transform shieldSprite;

    private void Update()
    {
        EnemyMovement();
        BombSpawn();
    }

    public void EnemyMovement()
    {        
        Vector3 direction = player.position - transform.position;
        transform.up = direction;

        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        
        //transform.position += transform.up;

    }

    public void BombSpawn()
    {        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            Instantiate(enemysBomb, transform.position, rotation);

            enemysBomb.GetComponent<EnemyBombs>().shieldSprite = shieldSprite;
        }
    }


}
