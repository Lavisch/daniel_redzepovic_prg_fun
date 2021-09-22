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
    public float maxSpeed = 5;

    public Circle()
    {

    }

    public Circle(Vector2 pos, float r)
    {
        this.pos = pos;
        this.r = r;
    }

    public void Draw()
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
        acc += f;
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

    public void WrapXBounceY()
    {
        //Wrapping
        if (pos.x > Width + r)
        {
            pos.x = 0 + r;
        }
        if (pos.x < 0 - r)
        {
            pos.x = Width - r;
        }
        //Bouncing
        if (pos.y < r)
        {
            pos.y = r;
            vel.y *= -1;
        }
        if (pos.y > Height - r)
        {
            pos.y = Height - r;
            vel.y *= -1;
        }
    }

    public void PeekX()
    {
        if (pos.x > Width - r && pos.x < Width + r)
        {
            Fill(color[0], color[1], color[2]);
            Circle(pos.x - Width, pos.y, r * 2);
        }
        if (pos.x < r && pos.x > 0 - r)
        {
            Fill(color[0], color[1], color[2]);
            Circle(pos.x + Width, pos.y, r * 2);
        }
    }
}
