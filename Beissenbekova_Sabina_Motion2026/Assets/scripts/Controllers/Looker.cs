using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Looker : MonoBehaviour
{
    public List<Transform> objects;
    int i;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 direction = objects[i].position - transform.position;
        float facingAngle = Player.VectorToAngle(direction);

        transform.eulerAngles = new Vector3 (0, 0, facingAngle);

      
            
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                i++;
                if(i >= objects.Count)
                {
                    i = 0;
                }

            }

        

    }
}
