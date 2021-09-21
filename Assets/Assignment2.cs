using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
    ParabolicCurve pc1, pc2, pc3, pc4;
    //Corner pos
    public float x1;
    public float y1;
    //Opposite corner pos
    public float x2;
    public float y2;

    public int numberOfLines;
    public int strokeAlpha; //Stroke opacity (0-255)
    int tickRate = 24; //Number of ticks per second
    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        //Arbitrary starting properties
        numberOfLines = 16;
        strokeAlpha = 128;

        //Arbitrary corner starting pos
        x1 = (Width - Height) / 2;
        y1 = 0;
        x2 = Width - (Width - Height) / 2;
        y2 = Height;

        pc1 = new ParabolicCurve();
        pc2 = new ParabolicCurve();
        pc3 = new ParabolicCurve();
        pc4 = new ParabolicCurve();

        InvokeRepeating(nameof(Tick), 0, 1f / tickRate);
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
    }

    // Tick is called tickRate times per second
    void Tick()
    {
        pc1.SetProperties(x1, y1, x1, y2, MouseX, MouseY, numberOfLines, strokeAlpha);
        pc2.SetProperties(x2, y2, x1, y2, MouseX, MouseY, numberOfLines, strokeAlpha);
        pc3.SetProperties(x2, y2, x2, y1, MouseX, MouseY, numberOfLines, strokeAlpha);
        pc4.SetProperties(x1, y1, x2, y1, MouseX, MouseY, numberOfLines, strokeAlpha);
        
        pc1.ShiftColors();
        pc2.ShiftColors();
        pc3.ShiftColors();
        pc4.ShiftColors();
    }

    //Draw is called frameRate times per second
    void Draw()
    {
        Background(0);
        pc1.DrawParabolicCurve();
        pc2.DrawParabolicCurve();
        pc3.DrawParabolicCurve();
        pc4.DrawParabolicCurve();
    }
}
