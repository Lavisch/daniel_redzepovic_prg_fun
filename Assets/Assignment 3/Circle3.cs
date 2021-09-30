using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used in Assignment 3
public class Circle3 : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 vel;

    public float r;
    public int[] color;
    public float maxSpeed = 5;

    public Circle3()
    {

    }

    public Circle3(Vector2 pos, float r)
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
        pos += vel * Time.deltaTime;
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
}
