using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform targetTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.red);

        Vector3 direciton = targetTransform.position - transform.position;

        bool shouldWeTurnRight = false;

        //Player.VectorDot()

    }
}
