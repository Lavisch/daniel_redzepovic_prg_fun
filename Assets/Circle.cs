using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 velocity;

    private float r;
    public int[] color;
    public float maxSpeed = 10;
 
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
    
    public void TeleportCircle(Vector2 pos)
    {
        this.pos = pos;
        velocity *= 0;
    }

    public void MoveCircle()
    {
        pos +=  Vector2.ClampMagnitude(velocity * Time.deltaTime, maxSpeed);
        if (pos.x > Width - r || pos.x < r)
        {
            velocity.x *= -1;
        }
        if (pos.y > Height - r || pos.y < r)
        {
            velocity.y *= -1;
        }
    }
}
