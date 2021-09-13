using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    public int lines = 8;
    public float startX = 7;
    public float endX = 8;
    public float startY = 9;
    public float endY = 1;
    public float offSetX = -4;
    public float offSetY = 2;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float spacingX = (startX - endX) / lines;
        float spacingY = (startY - endY) / lines;

        Background(255, 255, 255);

        for (int i = 0; i < lines; i++)
        {
            float offSetXStart = offSetX * i / lines;
            float offSetXEnd = offSetX * (lines - i) / lines;
            float offSetYStart = offSetY * i / lines;
            float offSetYEnd = offSetY * (lines - i) / lines;

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
                startX + offSetXStart,
                startY - i * spacingY + offSetYStart,
                startX + (i + 1) * spacingX + offSetXEnd,
                endY + offSetYEnd
            );
        }
    }
}
