using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurve : ProcessingLite.GP21
{
    public int numberOfLines;
    public float x1;
    public float y1;
    public float x2;
    public float y2;
    public float x3;
    public float y3;

    public int[][] colors = new int[][]
    {
        new int[] {255, 0, 0},    //Red
        new int[] {255, 127, 0},  //Orange
        new int[] {255, 255, 0},  //Yellow
        new int[] {0, 255, 0},    //Green
        new int[] {0, 0, 255},    //Blue
        new int[] {75, 0, 130},   //Indigo
        new int[] {148, 0, 211}   //Violet
    };

    public ParabolicCurve()
    {

    }

    public ParabolicCurve(float x1, float y1, float x2, float y2, float x3, float y3, int numberOfLines)
	{
        this.numberOfLines = numberOfLines;
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
    }

    public void DrawParabolicCurve()
    {
        Background(0, 0, 0);

        for (int i = 0; i < numberOfLines; i++)
        {

            float x1 = this.x1 + ((x3 - this.x1) * i / numberOfLines);
            float y1 = this.y1 + ((y3 - this.y1) * i / numberOfLines);
            float x2 = x3 + ((this.x2 - x3) * (i + 1) / numberOfLines);
            float y2 = y3 + ((this.y2 - y3) * (i + 1) / numberOfLines);

            int j = (i % (colors.Length - 1));

            int r = colors[j][0];
            int g = colors[j][1];
            int b = colors[j][2];

            Stroke(r, g, b);
            Line(x1, y1, x2, y2);
        }
    }
}
