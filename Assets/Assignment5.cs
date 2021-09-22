using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    Player myPlayer;
    float r = 0.3f;

    Ball[] balls;
    int numberOfBalls = 10;

    float maxSpeed = 8;

    int frameRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = new Player(new Vector2(Width / 3, Height / 2), r)
        {
            color = new int[] { 255, 0, 0 },
            maxSpeed = this.maxSpeed
        };
        
        balls = new Ball[numberOfBalls];
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(new Vector2(Width / 2, Height / 2), r)
            {
                color = new int[] {255, 255, 255},
                maxSpeed = this.maxSpeed
            };
        }
        NoStroke();
        InvokeRepeating(nameof(Draw), 0, 1f / frameRate);
    }

    // Update is called once per frame
    void Update()
    {
        myPlayer.UpdatePos();
        myPlayer.Control(maxSpeed);
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
        }
    }

    void Draw()
    {
        Background(0);
        myPlayer.Draw();
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].Draw();
        }

    }


}