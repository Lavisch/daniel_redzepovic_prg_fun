using System.Collections.Generic;
using UnityEngine;

public class DanRed : IRandomWalker
{
	//Add your own variables here.
	//Do not use processing variables like width or height

	public int playAreaWidth;
	public int playAreaHeight;

	public Vector2 position;
	public Vector2 lastMove;

	public List<Vector2> visitedSpots = new List<Vector2>();
	public Vector2[] allMoves = { Vector2.right, Vector2.left, Vector2.up, Vector2.down };
	public Vector2[] preferredMoves;

	public string GetName()	
	{
		return "Daniel"; //When asked, tell them our walkers name
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		//Select a starting position or use a random one.
		float x = Random.Range(0, playAreaWidth);
		float y = Random.Range(0, playAreaHeight);

		position = new Vector2(x, y);

		this.playAreaWidth = playAreaWidth;
		this.playAreaHeight = playAreaHeight;

		//a PVector holds floats but make sure its whole numbers that are returned!
		return new Vector2(x, y);
	}

	public Vector2 Movement()
	{
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.

        if (!visitedSpots.Contains(position))
			visitedSpots.Add(position);

		Vector2 move = GetMove();
		position += move;
		return move;
	}

    private Vector2 GetMove()
    {
		if (lastMove == Vector2.zero)
        {
			preferredMoves = allMoves;
        }
        else
        {
            for (int i = 0, j = 0; i < allMoves.Length; i++)
            {
                if (allMoves[i] != lastMove * -1)
                {
					preferredMoves[j] = allMoves[i];
					j++;
                }
            }
        }

		int r = Random.Range(0, preferredMoves.Length);
		Vector2 backupMove = lastMove * -1;

        for (int i = 0; i < preferredMoves.Length; i++, r++)
        {
			Vector2 move = preferredMoves[r % preferredMoves.Length];

			if (IsValidMove(move))
            {
				backupMove = move;
                if (!HasVisited(move))
                {
					return move;
                }
            }
        }
		return backupMove; 
    }

	private bool IsValidMove(Vector2 move)
	{
		Vector2 newPosition = position + move;

        if ( newPosition.x > playAreaWidth || newPosition.x < 0 || newPosition.y > playAreaHeight || newPosition.y < 0)
			return false;
        else
			return true;
	}

	private bool HasVisited(Vector2 move)
    {
		Vector2 newPosition = position + move;

        if (visitedSpots.Contains(newPosition))
			return true;
        else
			return false;
	}
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!