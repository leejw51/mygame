using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int color;

    // Start is called before the first frame update
    void Start()
    {
        // set color to random 0~2
        color = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        // change sprite color by color
        switch (color)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
        
    }
}
