using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite
public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 pos; //Ball position
    public Vector2 vel; //Ball direction

    public float maxSpeed = 5;
    public float r = 0.5f;
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
    public virtual void UpdatePos()
    {
        vel = Vector2.ClampMagnitude(vel, maxSpeed);
        vel = Bounce(vel);
        pos += vel * Time.deltaTime;
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
    
    public bool Collision (Ball b)
    {
        float maxDistance = this.r + b.r;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(this.pos.x - b.pos.x) > maxDistance || Mathf.Abs(this.pos.y - b.pos.y) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(this.pos, b.pos) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
}