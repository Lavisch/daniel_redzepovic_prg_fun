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
            float x = Random.Range(ball.radius, Width - ball.radius);
            float y = Random.Range(ball.radius, Height - ball.radius);
            Vector2 pos = new Vector2(x, y);
            ball.position = pos;

            if (Collision(ball, player))
                i--;
            else
            {
                ball.color = color;
                ball.velocity = (player.position - pos).normalized * -1 * ball.speed; //Set ball velocity opposite to player pos
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
        float maxDistance = ball1.radius + ball2.radius;

        if (Mathf.Abs(ball1.position.x - ball2.position.x) > maxDistance || Mathf.Abs(ball1.position.y - ball2.position.y) > maxDistance)
            return false;

        else if (Vector2.Distance(ball1.position, ball2.position) > maxDistance)
            return false;

        else
            return true;
    }
}
