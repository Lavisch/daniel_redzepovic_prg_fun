using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    Circle c1, c2;
    float r = 0.5f;
    float v = 5;
    float a = 20;
    float friction = 10;
    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        c1 = new Circle(new Vector2(Width / 3, Height / 2), r);
        c1.color = new int[] { 255, 0, 0};

        c2 = new Circle(new Vector2(Width / 3 * 2, Height / 2), r);
        c2.color = new int[] { 0, 255, 0 };

        NoStroke();
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
    }

    // Update is called once per frame
    void Update()
    {
        c1.Move();
        c2.Move();
        c2.ApplyForce(c2.vel.normalized * -1 * friction);
        c1.BindToFrame();
        c2.BindToFrame();
        Control();
    }

    void Draw()
    {
        Background(0);
        c1.DrawCircle();
        c2.DrawCircle();
        Debug.Log(c1.vel);
    }

    private void Control()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            c1.vel.x += v;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            c1.vel.x = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            c2.ApplyForce(new Vector2(a, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            c1.vel.x -= v;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            c1.vel.x = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            c2.ApplyForce(new Vector2(-a, 0));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            c1.vel.y += v;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            c1.vel.y = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            c2.ApplyForce(new Vector2(0, a));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            c1.vel.y -= v;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            c1.vel.y = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            c2.ApplyForce(new Vector2(0, -a));
        }
    }
}
