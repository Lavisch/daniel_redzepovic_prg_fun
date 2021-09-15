using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    ParabolicCurve pc;
    public int numberOfLines;
    //Start coordinates
    public float x1;
    public float y1;
    //End coordinates
    public float x2;
    public float y2;
    //Corner coordinates
    public float x3;
    public float y3;

    //Number of ticks per second
    int tickRate = 30; 

    // Start is called before the first frame update
    void Start()
    {
        numberOfLines = 75;
        x1 = 0;
        y1 = Height;
        x2 = Width;
        y2 = Height;
        x3 = Width / 2;
        y3 = 0;

        pc = new ParabolicCurve(x1, y1, x2, y2, x3, y3, numberOfLines);
        InvokeRepeating(nameof(Tick), 0, 1f / tickRate);
    }

    void Tick()
    {
        MathCraft(pc);
        pc.DrawParabolicCurve();
        pc.x1 = x1;
        pc.y1 = y1;
        pc.x2 = x2;
        pc.y2 = y2;
        pc.x3 = x3;
        pc.y3 = y3;
        pc.numberOfLines = numberOfLines;
        
    }

    void MathCraft(ParabolicCurve pc)
    {
        int[] firstColor = pc.colors[0];
        for (int i = 0; i < pc.colors.Length - 1; i++)
        {
            pc.colors[i] = pc.colors[i + 1];
        }
        pc.colors[pc.colors.Length - 1] = firstColor;

    }
}
