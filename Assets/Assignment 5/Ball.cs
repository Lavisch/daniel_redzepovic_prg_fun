using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    public Vector2 position;
    public Vector2 velocity;

    public float speed = 8;
    public float radius = 0.3f;
    public int[] color = { 255, 255, 255 };

    public Ball(Vector2 pos, float r = 0.3f, float speed = 8)
    {
        this.position = pos;
        this.radius = r;
        this.speed = speed;
    }
    
    //Empty constructor necessary
    public Ball()
    {

    }

    public void Draw()
    {
        Fill(color[0], color[1], color[2]);
        Circle(position.x, position.y, radius * 2);
    }

    public virtual void UpdatePos()
    {
        Bounce();

        if (velocity.magnitude > speed)
            velocity = velocity.normalized * speed;

        position += velocity * Time.deltaTime;
    }

    public void Bounce()
    {
        if (position.x > Width - radius || position.x < radius)
            velocity.x *= -1;

        if (position.y > Height - radius || position.y < radius)
            velocity.y *= -1;
    }
}