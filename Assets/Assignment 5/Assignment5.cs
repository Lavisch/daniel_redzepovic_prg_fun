using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    Player player;
    public float playerRadius = 0.5f;
    
    public BallManager ballManager;
    public int numberOfBalls = 10;

    int frameRate = 60;
    bool running;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(new Vector2(Width / 2, Height / 2));
        player.color = new int[] { 0, 255, 0 };

        ballManager = new BallManager(numberOfBalls, player);
        
        NoStroke();
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
        InvokeRepeating(nameof(AddOneBall), 3, 3);

        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
            Play();
        else
        { 
            DrawGameOver();
            if (Input.anyKey)
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
        ballManager.AddBalls(1, player);
    }

    void Draw()
    {
        Background(0);
        player.Draw();
        ballManager.DrawBalls();
    }

    private void DrawGameOver()
    {
        float stretch = 0.8f;

        Background(0);
        StrokeWeight(8);
        Stroke(255, 0, 0);
        Line(Width * stretch, Height * stretch, Width - Width * stretch, Height - Height * stretch);
        Line(Width * stretch, Height - Height * stretch, Width - Width * stretch, Height * stretch);
    }
}