using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ball
{
    public Player(Vector2 pos) : base(pos)
    {
        this.pos = pos;
    }
    public Player(Vector2 pos, float r) : base(pos, r)
    {
        this.pos = pos;
        this.r = r;
    }

    public override void UpdatePos()
    {
        vel = Vector2.ClampMagnitude(vel, speed);
        pos += vel * Time.deltaTime;
        pos = new Vector2(Mathf.Clamp(pos.x, r, Width - r), Mathf.Clamp(pos.y, r, Height - r));
    }

    public void Control()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        vel = direction * speed;
    }
}
