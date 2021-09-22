using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ball
{
    public Player(Vector2 pos, float r) : base(pos, r)
    {
        this.r = r;
        this.pos = pos;
    }

    public override void UpdatePos()
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
