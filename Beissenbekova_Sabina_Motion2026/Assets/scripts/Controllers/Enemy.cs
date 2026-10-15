using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float speed = 1;    
    public GameObject enemysBomb;
    public Transform shieldSprite;

    public float timer = 0f;

    private void Update()
    {
        EnemyMovement();

        timer += Time.deltaTime;

        if (timer > 1f)
        {            
            timer = 0f;
            BombSpawn();
        }
        
                
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
         Vector3 direction = player.position - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

         Quaternion rotation = Quaternion.Euler(0, 0, angle);
         GameObject clone = Instantiate(enemysBomb, transform.position, rotation);

         clone.GetComponent<EnemyBombs>().shieldSprite = shieldSprite;
        
    }


}
