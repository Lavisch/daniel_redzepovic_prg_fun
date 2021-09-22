using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{
    Circle3 c;
    public Vector2 pos; //Starting pos
    public float r = 0.5f; //Circle radius
    public int[] color = new int[] { 255, 255, 255 };
    public float maxSpeed = 10;

    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector2 (Width / 2, Height / 2);

        c = new Circle3(pos, r)
        {
            color = this.color,
            maxSpeed = this.maxSpeed
        };

        InvokeRepeating(nameof(Draw), 0, 1.0f / frameRate);
    }

    void Draw()
    {
        Background(0);
        if (Input.GetMouseButton(0))
        {
            Line(c.pos.x, c.pos.y, MouseX, MouseY);
        }
        c.Draw();
    }

    void Update()
    {
        c.Move();
        c.Bounce();
        if (Input.GetMouseButtonDown(0))
        {
            c.Teleport(new Vector2(MouseX, MouseY));
        }
        if (Input.GetMouseButtonUp(0))
        {
            c.vel = (new Vector2(MouseX, MouseY) - c.pos);
        }
    }
}
