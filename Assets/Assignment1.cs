using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    public float startX = 4;
    public float startY = 7;

    public float spacing = 1;
    public float letterWidth = 2;
    public float letterHeight = 4;
    public float strokeWidth = 2;
    int r, g = 50, b = 100; //RGB values (0-255)
    
    int frameCount = 0;
    int stage = 0; //Controls animation stages (0-255), should not be changed
    int tickDelay = 5; //Higher tickDelay = slower animation
    float animationMul = 1.5f; //Higher animationMul = crazier animations

    bool reverse = false;

    float letterCount = 6;

    // Start is called before the first frame update
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        if (frameCount % tickDelay == 0)
        {
            Animate();
            frameCount = 0;
        }
        frameCount++;
    }

    private void Animate()
    {
        StrokeWeight(strokeWidth);
        r = stage;

        if (stage >= 255)
        {
            reverse = true;
        }

        if (stage <= 0)
        {
            reverse = false;
        }

        if (reverse)
        {
            Background(r, g, b);
            spacing -= animationMul / 500;
            startX += animationMul * (letterCount - 1) / 2 / 500; //To compensate for spacing increase/decrease: * (letterCount - 1) / 2
            strokeWidth -= animationMul / 50;
            stage--;
        }
        else
        {
            Background(r, g, b);
            spacing += animationMul / 500;
            startX -= animationMul * (letterCount - 1) / 2 / 500;
            strokeWidth += animationMul / 50;
            stage++;
        }

        Fill(255 - r, 255 - g, 255 - b);
        NoStroke();
        Circle(MouseX, MouseY, (letterHeight + 5) * (stage + 128) / 255);
        
        float x = startX;
        float y = startY;

        Stroke(240, 240, 240);

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
