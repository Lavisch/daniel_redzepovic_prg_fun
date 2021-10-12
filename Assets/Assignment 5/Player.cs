using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ball
{
    public Player(Vector2 pos) : base(pos)
    {
        this.position = pos;
    }

    public override void UpdatePos()
    {
        velocity = Vector2.ClampMagnitude(velocity, speed);
        position += velocity * Time.deltaTime;
        position = new Vector2(Mathf.Clamp(position.x, radius, Width - radius), Mathf.Clamp(position.y, radius, Height - radius));
    }

    public void Control()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = direction * speed;
    }
}
