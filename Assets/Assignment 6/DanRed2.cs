using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanRed2 : IRandomWalker
{
	public Vector2 position;
	public Vector2 lastMove;

	public Vector2[] allMoves = { Vector2.right, Vector2.left, Vector2.up, Vector2.down };
	public Vector2[] preferredMoves;

	bool[,] visited;

	public string GetName()
	{
		return "Daniel"; //When asked, tell them our walkers name
	}

	public Vector2 Movement()
	{
		//add your own walk behavior for your walker here.
		//Make sure to only use the outputs listed below.

		switch (Random.Range(0, 4))
		{
			case 0:
				return new Vector2(-1, 0);
			case 1:
				return new Vector2(1, 0);
			case 2:
				return new Vector2(0, 1);
			default:
				return new Vector2(0, -1);
		}
	}

	public Vector2 GetStartPosition(int width, int height)
	{
		Setup(width, height);
		
		//Select a starting position or use a random one.
		float x = Random.Range(0, width);
		float y = Random.Range(0, height);
		position = new Vector2(x, y);

		//a PVector holds floats but make sure its whole numbers that are returned!
		return new Vector2(x, y);
	}

    public void Setup(int width, int height)
    {
        //throw new System.NotImplementedException();
		
		visited = new bool[width, height];

        for (int i = 0; i < visited.GetLength(0); i++)
        {
            for (int j = 0; j < visited.GetLength(1); j++)
            {
                visited[i, j] = false;
                Debug.Log(i + " " + j + " " + visited[i, j]);
            }
        }
    }
}
