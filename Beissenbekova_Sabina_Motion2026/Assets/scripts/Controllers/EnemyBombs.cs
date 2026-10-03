using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyBombs : MonoBehaviour
{
    public float speed = 2f;
    public Transform player;
    public Transform enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        Vector3 direction = (player.position - enemy.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime); 
    }


}
