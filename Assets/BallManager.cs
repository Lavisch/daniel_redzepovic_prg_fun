using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : ProcessingLite.GP21
{
    public List<Ball> balls = new List<Ball>();
    public int[] color = { 255, 255, 255 };

    public BallManager(int numberOfBalls, Player player)
    {
        AddBalls(numberOfBalls, player);
    }

    public void AddBalls(int numberOfBalls, Player player)
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            //Create a ball with random position
            Ball ball = new Ball();
            Vector2 pos = new Vector2(Random.Range(ball.r, Width - ball.r), Random.Range(ball.r, Height - ball.r));
            ball.pos = pos;

            //Check if a ball would not collide with player if created at pos
            if (Collision(ball, player))
                i--;
            else
            {
                ball.color = color;
                //Set ball velocity in opposite direction in relation to player pos
                ball.vel = (player.pos - pos).normalized * -1 * ball.speed;
                balls.Add(ball);
            }
        }
    }

    public void UpdatePos()
    {
        for (int i = 0; i < balls.Count; i++)
            balls[i].UpdatePos();
    }

    public void DrawBalls()
    {
        for (int i = 0; i < balls.Count; i++)
            balls[i].Draw();
    }

    public bool Collision(Ball ball1, Ball ball2)
    {
        float maxDistance = ball1.r + ball2.r;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(ball1.pos.x - ball2.pos.x) > maxDistance || Mathf.Abs(ball1.pos.y - ball2.pos.y) > maxDistance)
            return false;
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(ball1.pos, ball2.pos) > maxDistance)
            return false;
        //We now know the points are closer then the distance so we are colliding!
        else
            return true;
    }
}
