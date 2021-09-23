using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    Player player;
    public float playerRadius = 0.5f;
    
    public BallManager ballManager;
    public int numberOfBalls = 10;
    public float ballRadius = 0.3f;

    int frameRate = 60;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(new Vector2(Width / 2, Height / 2), playerRadius);
        player.color = new int[] { 255, 0, 0 };

        ballManager = new BallManager(numberOfBalls, ballRadius, player);
        
        NoStroke();
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
        InvokeRepeating(nameof(AddOneBall), 3, 3);

        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            Play();
        }
        else if (Input.anyKey)
        {
            Start();
        }
    }

    void Play()
    {
        player.Control();
        player.UpdatePos();
        ballManager.UpdatePos();

        //Look for collision and end round if found
        for (int i = 0; i < ballManager.balls.Count; i++)
        {
            if (ballManager.Collision(ballManager.balls[i], player))
            {
                running = false;
                CancelInvoke();
            }
        }
    }

    void AddOneBall()
    {
        ballManager.AddBalls(1, ballRadius, player);
    }

    void Draw()
    {
        Background(0);
        player.Draw();
        ballManager.Draw();
    }
}