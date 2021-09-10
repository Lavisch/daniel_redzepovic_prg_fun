using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    float startX = 4;
    float startY = 7;

    float spacing = 1;
    float letterWidth = 2;
    float letterHeight = 4;
    float strokeWidth = 2;
    int r = 0, g = 50, b = 100; //RGB values (0-255)
    
    int countFrames = 0; 
    int tickDelay = 5; //Higher tickDelay = slower animation
    float animationMul = 2; //Higher animationMul = crazier animations

    bool reverse = false;

    float letterCount = 6;

    // Start is called before the first frame update
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        if (countFrames % tickDelay == 0)
        {
            Animate();
        }
        countFrames++;
    }

    private void Animate()
    {
        if (r >= 255)
        {
            reverse = true;
        }

        if (r <= 0)
        {
            reverse = false;
        }

        if (reverse)
        {
            Background(r, g, b);
            spacing -= animationMul / 1000;
            startX += animationMul * (letterCount - 1) / 2 / 1000; //To compensate for spacing increase/decrease: * (letterCount - 1) / 2
            strokeWidth -= animationMul / 50;
            r--;
        }
        else
        {
            Background(r, g, b);
            spacing += animationMul / 1000;
            startX -= animationMul * (letterCount - 1) / 2 / 1000;
            strokeWidth += animationMul / 50;
            r++;
        }

        StrokeWeight(strokeWidth);

        float x = startX;
        float y = startY;

        DrawD(x, y);

        x += letterWidth + spacing;
        DrawA(x, y);

        x += letterWidth + spacing;
        DrawN(x, y);

        x += letterWidth + spacing;
        DrawI(x, y);

        x += spacing;
        DrawE(x, y);

        x += letterWidth + spacing;
        DrawL(x, y);
    }

    //Draws a vertical line down from pos x y
    private void VertLine(float x, float y)
    {
        Line(x, y, x, y - letterHeight);
    }

    private void DrawD(float x, float y)
    {
        VertLine(x, y);
        Line(x, y, x + letterWidth, y - letterHeight / 3);
        Line(x + letterWidth, y - letterHeight / 3, x + letterWidth, y - letterHeight / 3 * 2);
        Line(x + letterWidth, y - letterHeight / 3 * 2, x, y - letterHeight);
    }

    private void DrawA(float x, float y)
    {
        Line(x + letterWidth / 2, y, x, y - letterHeight);
        Line(x + letterWidth / 2, y, x + letterWidth, y - letterHeight);
        Line(x + letterWidth / 4, y - letterHeight / 2, x + letterWidth / 4 * 3, y - letterHeight / 2);
    }

    private void DrawN(float x, float y)
    {
        VertLine(x, y);
        Line(x, y, x + letterWidth, y - letterHeight);
        VertLine(x + letterWidth, y);
    }

    private void DrawI(float x, float y)
    {
        VertLine(x, y);
    }

    private void DrawE(float x, float y)
    {
        VertLine(x, y);
        Line(x, y, x + letterWidth, y);
        Line(x, y - letterHeight / 2, x + letterWidth / 2, y - letterHeight / 2);
        Line(x, y - letterHeight, x + letterWidth, y - letterHeight);
    }

    private void DrawL(float x, float y)
    {
        VertLine(x, y);
        Line(x, y - letterHeight, x + letterWidth, y - letterHeight);
    }

}
