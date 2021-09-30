using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite
public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 pos; //Ball position
    public Vector2 vel; //Ball direction

    public float speed = 8;
    public float r = 0.3f;
    public int[] color = { 255, 255, 255 };

    //Ball Constructor, called when we type new Ball(pos);
    public Ball(Vector2 pos, float r = 0.3f, float speed = 8)
    {
        this.pos = pos;
        this.r = r;
        this.speed = speed;
    }
   
    public Ball()
    {

    }

    //Draw our ball
    public void Draw()
    {
        Fill(color[0], color[1], color[2]);
        Circle(pos.x, pos.y, r * 2);
    }

    //Update our ball
    public virtual void UpdatePos()
    {
        Bounce();
        if (vel.magnitude > speed)
            vel = vel.normalized * speed;
        pos += vel * Time.deltaTime;
    }

    public void Bounce()
    {
        if (pos.x > Width - r || pos.x < r)
            vel.x *= -1;
        if (pos.y > Height - r || pos.y < r)
            vel.y *= -1;
    }
}