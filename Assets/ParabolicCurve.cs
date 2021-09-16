using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurve : ProcessingLite.GP21
{
    private int numberOfLines;
    private float x1;
    private float y1;
    private float x2;
    private float y2;
    private float x3;
    private float y3;
    int strokeAlpha;

    //List of colors
    public int[][] colors = new int[][]
    {
        new int[] {255, 0, 0,},    //Red
        new int[] {255, 127, 0,},  //Orange
        new int[] {255, 255, 0,},  //Yellow
        new int[] {0, 255, 0,},    //Green
        new int[] {0, 0, 255,},    //Blue
        new int[] {75, 0, 130,},   //Indigo
        new int[] {148, 0, 211,}   //Violet
    };

    public ParabolicCurve()
    {

    }

    public ParabolicCurve(float x1, float y1, float x2, float y2, float x3, float y3, int numberOfLines, int strokeAlpha)
	{
        SetProperties(x1, y1, x2, y2, x3, y3, numberOfLines, strokeAlpha);
    }
 
    public void SetProperties(float x1, float y1, float x2, float y2, float x3, float y3, int numberOfLines, int strokeAlpha)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.x3 = x3;
        this.y3 = y3;
        this.numberOfLines = numberOfLines;
        this.strokeAlpha = Mathf.Clamp(strokeAlpha, 0, 255);
    }

    public void DrawParabolicCurve()
    {
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

            Stroke(r, g, b, strokeAlpha);
            Line(x1, y1, x2, y2);
        }
    }

    public void ShiftColors()
    {
        int[] firstColor = colors[0];
        for (int i = 0; i < colors.Length - 1; i++)
        {
            colors[i] = colors[i + 1];
        }
        colors[colors.Length - 1] = firstColor;
    }
}
