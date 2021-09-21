using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;

    public float r;
    public int[] color;
    public float maxSpeed = 1;

    public Circle()
    {

    }

    public Circle(Vector2 pos, float r)
    {
        this.pos = pos;
        this.r = r;
    }

    public void DrawCircle()
    {
        Fill(color[0], color[1], color[2]);
        Circle(pos.x, pos.y, r * 2);
    }
    
    public void Teleport(Vector2 pos)
    {
        this.pos = pos;
        vel *= 0;
    }

    public void Move()
    {
        vel = Vector2.ClampMagnitude(vel + acc * Time.deltaTime, maxSpeed);
        pos += vel * Time.deltaTime;
        acc *= 0;
    }

    public void ApplyForce(Vector2 f)
    {
        acc += acc * Time.deltaTime + f;
    }

    public void Bounce()
    {
        if (pos.x > Width - r || pos.x < r)
        {
            vel.x *= -1;
        }
        if (pos.y > Height - r || pos.y < r)
        {
            vel.y *= -1;
        }
    }

    public void BindToFrame()
    {
        if (pos.x > Width - r)
        {
            pos.x = Width - r;
        }
        if (pos.x < r)
        {
            pos.x = r;
        }
        if (pos.y > Height - r)
        {
            pos.y = Height - r;
        }
        if (pos.y < r)
        {
            pos.y = r;
        }
    }
}
