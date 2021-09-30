using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ProcessingLite.GP21
{
    public List<Vector2> visitedSpots = new List<Vector2>();

    Vector2 up1 = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {
        //visitedSpots.Add(Vector2.zero);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(!visitedSpots.Contains(Vector2.zero));
        }
    }

}
