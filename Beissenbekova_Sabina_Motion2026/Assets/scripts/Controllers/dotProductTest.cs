using UnityEngine;

public class dotProductTest : MonoBehaviour
{
    public float redAngle;
    public float blueAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 redvector = new Vector3(Mathf.Cos(redAngle), Mathf.Sin(redAngle)) * Mathf.Deg2Rad;
        Vector3 bluevector = new Vector3(Mathf.Cos(blueAngle), Mathf.Sin(blueAngle)) * Mathf.Deg2Rad;

        Debug.DrawLine(Vector3.zero, bluevector, Color.blue);
        Debug.DrawLine(Vector3.zero, redvector, Color.red);

        Debug.Log(Player.VectorDot(redvector, bluevector));


    }
}
