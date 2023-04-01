using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;
    private const int Width = 10;
    private const int Height = 10;
    private readonly Vector3 _start = new Vector3(-5, -5, 0);
    private readonly GameObject[] _candies = new GameObject[Width * Height];

    private void Start()
    {
        Debug.Log("Hello World");
        
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                GameObject candy = Instantiate(candyPrefab);
                candy.transform.position = new Vector3(x, y, 0) + _start;
                _candies[y * Width + x] = candy;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
    }

    private void FillEmpty(int x, int y)
    {
        int index = y * Width + x;
        if (_candies[index] != null)
        {
            Debug.Log("No empty candy");
            return;
        }

        int my;
        // deep copy _candies 
        for (my = y; my <Height; my++)
        {
            int a=x + my * Width;
            int b=x + (my + 1) * Width;
            if (my<Height-1) {
              _candies[a] = _candies[b];
              _candies[b] = null;
            }
            else {
                _candies[a]=null;
            }
            if (_candies[a] != null)
            {
                _candies[a].transform.position = new Vector3(x, my, 0) + _start;
            }
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = Mathf.RoundToInt(mousePosition.x + 5f);
        int y = Mathf.RoundToInt(mousePosition.y + 5f);

        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            Debug.Log("Out of range");
            return;
        }

        int index = y * Width + x;
        if (_candies[index] == null)
        {
            Debug.Log("No candy");
            return;
        }

        Destroy(_candies[index]);
        _candies[index] = null;
        FillEmpty(x, y);
    }
}
