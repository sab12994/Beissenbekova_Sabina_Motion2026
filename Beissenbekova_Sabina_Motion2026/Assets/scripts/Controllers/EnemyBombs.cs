using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBombs : MonoBehaviour
{
    public float speed = 2f;
    public Transform player;
    public Transform enemy;

    public Transform shieldSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        //Vector3 direction = (player.position - enemy.position).normalized;
        transform.position += transform.up * speed * Time.deltaTime;

        float distance = Vector3.Distance(shieldSprite.position, transform.position);

        if (distance <= 0.9f)
        {
            Destroy(gameObject);
        }
    }


}
