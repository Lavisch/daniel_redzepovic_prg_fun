using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    Circle c;
    
    public Vector2 pos; //Starting pos
    public float r; //Circle radius
    public int[] circleColor;
    public float maxSpeed = 10;

    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2 (Width / 2, Height / 2);
        r = 1;
        circleColor = new int[] { 255, 255, 255 };

        c = new Circle(pos, r);
        c.color = circleColor;
        InvokeRepeating(nameof(Draw), 0, 1.0f / frameRate);
    }

    void Draw()
    {
        Background(0);
        if (Input.GetMouseButton(0))
        {
            Line(c.pos.x, c.pos.y, MouseX, MouseY);
        }
        c.DrawCircle();
    }

    void Update()
    {
        c.MoveCircle();
        if (Input.GetMouseButtonDown(0))
        {
            c.TeleportCircle(new Vector2(MouseX, MouseY));
        }
        if (Input.GetMouseButtonUp(0))
        {
            c.velocity = (new Vector2(MouseX, MouseY) - c.pos);
        }
    }
}
