using UnityEngine;

public class WalkerTest : ProcessingLite.GP21
{
	//This file is only for testing your movement/behavior.
	//The Walkers will compete in a different program!

	IRandomWalker walker;
	//DanRed walker;
	Vector2 walkerPos;
	float scaleFactor = 0.5f;

	void Start()
	{
		//Some adjustments to make testing easier
		Application.targetFrameRate = 120;
		QualitySettings.vSyncCount = 0;

		//Create a walker from the class Example it has the type of WalkerInterface
		walker = new DanRed();

		//Get the start position for our walker.
		walkerPos = walker.GetStartPosition((int)(Width / scaleFactor), (int)(Height / scaleFactor));

		Background(0);
		NoStroke();
		Fill(255, 255, 255, 10);
	}

	void Update()
	{
        if (Input.anyKeyDown)
        {
			//Draw the walker
			Circle(walkerPos.x * scaleFactor, walkerPos.y * scaleFactor, scaleFactor);
			//Get the new movement from the walker.
			walkerPos += walker.Movement();
        }
	}
}