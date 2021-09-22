using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    public Vector2 pos;
    public Vector2 vel;

    public float r;
    public int[] color;
    public float maxSpeed = 5;

    public Player()
    {

    }

    public Player(Vector2 pos, float r)
    {
        this.pos = pos;
        this.r = r;
    }

    public void Draw()
    {
        Fill(color[0], color[1], color[2]);
        Circle(pos.x, pos.y, r * 2);
    }

    public void UpdatePos()
    {
        vel = Vector2.ClampMagnitude(vel, maxSpeed);
        pos += vel * Time.deltaTime;
        pos = new Vector2(Mathf.Clamp(pos.x, r, Width - r), Mathf.Clamp(pos.y, r, Height - r));
    }

    public void Control(float speed)
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        vel = direction * speed;
    }
}
