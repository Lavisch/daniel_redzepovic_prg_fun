using UnityEngine;

public class RandomTest : ProcessingLite.GP21
{
	int timeStep = 0;
	float previusRandomValue = 0;
	float previusNoiseValue = 0;
	float previusCustomValue = 0;
	bool clearScreen = false;
	int[] gaussianNumbers;
	int gaussianSample = 200;

	void Start()
	{
		Application.targetFrameRate = 20;
		QualitySettings.vSyncCount = 0;

		StrokeWeight(0.5f);
		Background(0);
		gaussianNumbers = new int[gaussianSample];
	}

	void Update()
	{
		if (clearScreen)
		{
			Background(0);
			clearScreen = false;
		}

		if (Input.GetMouseButtonDown(0))
			MouseClicked();

		//Loop the program 100 times then pause
		if (timeStep > 100)
			return;

		//Draw the following graphs
		//Comment out to draw one at a time.
		DrawRandomGraph();          //White graph, Normal randomization
		DrawPerlinNoiseGraph();  //Green graph, perlin noise.
		DrawCustomGraph();          //Gold graph, a random graph that changes over time
		DrawNomalizedGraph();       //light gray dots, normalized distribution.

		//Move one tick.
		timeStep++;
	}

	//Restart the program on mouse click
	void MouseClicked()
	{
		clearScreen = true;
		timeStep = 0;
		gaussianNumbers = new int[200];
	}

	//Draw a graph with completely random numbers.
	void DrawRandomGraph()
	{
		Stroke(255);

		//Normal random value
		float y = Random.Range(0, Height);

		//Calculate X positions
		float oldX = (timeStep - 1) * Width / 100;
		float x = timeStep * Width / 100;

		//Draw a line from the last point to the new point
		Line(oldX, previusRandomValue, x, y);

		//Save the old point (we don't need X, it can be calculated)
		previusRandomValue = y;
	}

	void DrawPerlinNoiseGraph()
	{
		Stroke(0, 255, 0);

		//Nosie will give a value 0->1, multiply with height.
		//We give the function the current time and we will get values that affected by its neighbors.
		float y = Mathf.PerlinNoise(timeStep * 0.05f, 0) * Height;

		float oldX = (timeStep - 1) * Width / 100;
		float x = timeStep * Width / 100;

		Line(oldX, previusNoiseValue, x, y);

		previusNoiseValue = y;
	}

	void DrawCustomGraph()
	{
		Stroke(200, 200, 0);

		float y;

		//We can influence the random result by adding rules (formulas)
		do
		{
			y = Random.Range(0, Height);
		}
		while (y > timeStep * 0.1f + 2);

		float oldX = (timeStep - 1) * Width / 100;
		float x = timeStep * Width / 100;

		Line(oldX, previusCustomValue, x, y);

		previusCustomValue = y;
	}

	void DrawNomalizedGraph()
	{
		Stroke(200);

		//A normalized graph has to be done in a different way
		//Number closer to the middle should be more common.
		//We randomize 100 times each frame and summarize the results.
		for (int i = 0; i < gaussianSample; ++i)
		{
			//randomGaussian has no max or min value but its normalized
			int index;

			//Magic calculation for gaussian normailzation found online.
			float u1 = 1.0f - Random.Range(0, 1f); //uniform(0,1) random floats
			float u2 = 1.0f - Random.Range(0, 1f);
			float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) *
						 Mathf.Sin(2.0f * Mathf.PI * u2); //random normal(0,1)
			float randNormal = Width * 7 + 20 * randStdNormal; //random normal(mean,stdDev^2)

			//Make sure that we are in range of the index or otherwise skip it.
			index = Mathf.RoundToInt(randNormal);
			if (index > gaussianSample - 1 || index < 0)
				continue;

			//put each number found in the right part of the array
			gaussianNumbers[index]++;
		}

		//Draw the array.
		for (int i = 0; i < gaussianSample; ++i)
		{
			Point(i / Width, gaussianNumbers[i] / Height / 7);
		}
	}
}

