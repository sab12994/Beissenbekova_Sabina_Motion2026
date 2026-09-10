using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public int number;
    public TextMeshProUGUI score;
    float x;
    float y = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 B = new Vector2(x-1, -1);
        Vector2 L = new Vector2(x-1, y + 1);
        Vector2 D = new Vector2(x + 1, y + 1);
        Vector2 R = new Vector2(x + 1, y - 1);

        Debug.DrawLine(B, L, Color.white, 50);
        Debug.DrawLine(L, D, Color.white, 50);
        Debug.DrawLine(D, R, Color.white, 50);
        Debug.DrawLine(R, B, Color.white, 50);

        if (number == 0)
        {
            x = 0;
            
        }
        if(number == 1)
        {
            x = 2;
            
        }
        if (number == 2)
        {
            x = 4;
            
        }
        if (number == 3)
        {
            x = 6;
            
        }
        if (number == 4)
        {
            x = 8;
            
        }
        if (number == 5)
        {
            x = 10;
            
        }
    }
    

    public void pickARandom()
    {
        number += 1;
        if(number > 5)
        {
            number = 5;
        }
        score.text = number.ToString();
    }
}
