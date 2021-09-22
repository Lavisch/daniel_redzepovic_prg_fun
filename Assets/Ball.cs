using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite
class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 pos; //Ball position
    Vector2 vel; //Ball direction

    public float maxSpeed = 5;
    private float r = 0.5f;
    public int[] color = new int[] { 255, 255, 255 };

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(Vector2 pos, float r)
    {
        //Set our position when we create the code.
        this.r = r;
        this.pos = pos;

        //Create the velocity vector and give it a random direction.
        vel = new Vector2
        {
            x = Random.Range(-5, 6),
            y = Random.Range(-5, 6)
        };
        vel = vel.normalized * maxSpeed;
    }

    //Draw our ball
    public void Draw()
    {
        Fill(color[0], color[1], color[2]);
        Circle(pos.x, pos.y, r * 2);
    }

    //Update our ball
    public void UpdatePos()
    {
        pos += vel * Time.deltaTime;
        vel = Bounce(vel);
    }

    public Vector2 Bounce(Vector2 a)
    {
        if (pos.x > Width - r || pos.x < r)
        {
            a.x *= -1;
        }
        if (pos.y > Height - r || pos.y < r)
        {
            a.y *= -1;
        }
        return a;
    }
}