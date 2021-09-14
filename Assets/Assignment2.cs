using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    public int lines = 8;
    public float startX = 7;
    public float startY = 9;
    public float endX = 12;
    public float endY = 1;
    public float cornerX = 6;
    public float cornerY = 2;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Background(255, 255, 255);

        for (int i = 0; i < lines; i++)
        {
            float x1 = startX + ((cornerX - startX) * i / lines);
            float y1 = startY + ((cornerY - startY) * i / lines);
            float x2 = cornerX + ((endX - cornerX) * (i + 1) / lines);
            float y2 = cornerY + ((endY - cornerY) * (i + 1) / lines);

            Stroke(128, 128, 128);
            Circle(startX, startY, 0.2f);
            Circle(cornerX, cornerY, 0.2f);
            Circle(endX, endY, 0.2f);

            if (i % 3 == 0)
            {
                Stroke(0, 0, 0);
            }

            Line(x1, y1, x2, y2);
        }
    }
}
