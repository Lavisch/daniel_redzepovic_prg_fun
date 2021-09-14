using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    public int lines = 8;
    public float startX = 7;
    public float endX = 12;
    public float startY = 9;
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
            //Working code
            /*
            float offsetXStart = (cornerX - startX) * i / lines;
            float offsetXEnd = (endX - cornerX) * i / lines;
            float offsetYStart = (cornerY - startY) * i / lines;
            float offsetYEnd = (endY - cornerY) * i / lines;
            */

            float offsetXStart = (cornerX - startX) * i / lines;
            float offsetXEnd = (endX - cornerX) * (i + 1) / lines;
            float offsetYStart = (cornerY - startY) * i / lines;
            float offsetYEnd = (endY - cornerY) * (i + 1) / lines;

            if (i % 3 == 0)
            {
                Stroke(128, 128, 128);
            }
            else
            {
                Stroke(0, 0, 0);
            }

            Line
            (
                startX + offsetXStart,
                startY + offsetYStart,
                cornerX + offsetXEnd,
                cornerY + offsetYEnd
            );
            Circle(startX, startY, 0.2f);
            Circle(cornerX, cornerY, 0.2f);
            Circle(endX, endY, 0.2f);

        }
    }
}
