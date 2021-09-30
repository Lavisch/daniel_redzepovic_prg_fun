using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    Circle4 c1, c2;
    float r = 0.5f;

    public float velocity = 10;
    public float acceleration = 50;
    public float maxSpeed = 8;

    public float friction = 10;
    public float gravity = 20;

    public bool gravityOn = false; //Press 'g' to toggle
    public bool frictionOn = true; //Press 'f' to toggle

    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        c1 = new Circle4(new Vector2(Width / 3, Height / 2), r)
        {
            color = new int[] { 255, 0, 0 },
            maxSpeed = maxSpeed
        };

        c2 = new Circle4(new Vector2(Width / 3 * 2, Height / 2), r)
        {
            color = new int[] { 0, 255, 0 },
            maxSpeed = maxSpeed
        };

        NoStroke();
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
    }

    // Update is called once per frame
    void Update()
    {
        c1.Move();
        c2.Move();

        if (gravityOn)
        {
            c2.ApplyForce(new Vector2(0, gravity * -1));
        }
        if (frictionOn)
        {
            c2.ApplyForce(-1 * friction * c2.vel.normalized);
        }

        c1.WrapXBounceY();
        c2.WrapXBounceY();

        Control();
    }

    void Draw()
    {
        Background(0);

        c1.Draw();
        c2.Draw();

        c1.PeekX();
        c2.PeekX();
    }

    private void Control()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        c1.vel = direction * velocity;
        c2.ApplyForce(direction * acceleration);

        if (gravityOn && Input.GetKeyDown(KeyCode.G))
        {
            gravityOn = false;
        }
        else if (!gravityOn && Input.GetKeyDown(KeyCode.G))
        {
            gravityOn = true;
        }
        if (frictionOn && Input.GetKeyDown(KeyCode.F))
        {
            frictionOn = false;
        }
        else if (!frictionOn && Input.GetKeyDown(KeyCode.F))
        {
            frictionOn = true;

        }
    }
}