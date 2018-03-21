using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBrain : MonoBehaviour
{
    float timeBetweenCubes = 100.0f; // Time between each cube glowing
	bool waiting = false;
    public List<GameObject> allCubes = new List<GameObject>(); // List to store all the cubes in the scene
    public List<GameObject> patternCubes = new List<GameObject>(); // Cubes in the pattern

    // Find all cubes in the scene
    void FindAllCubes()
    {
        foreach (GameObject cubeObj in GameObject.FindGameObjectsWithTag("ColorCube"))
        {
            allCubes.Add(cubeObj);
        }
    }

    // Randomly pick a varying number of cubes
    void CubesInPattern()
    {
        int numberOfCubes = Random.Range(4, 7);

        for (int i = 0; i < numberOfCubes; i++)
        {
            patternCubes.Add(allCubes[Random.Range(0, allCubes.Count)]);
        }
    }

    void Start()
    {
        FindAllCubes();
        CubesInPattern();
		GlowCubes();

        // foreach (GameObject cube in patternCubes)
        // {
		// 	cube.GetComponent<Glow>().GlowTheCubes();
		// 	Debug.Log(cube.name + " is glowing");
        // }
    }

	void GlowCubes()
	{
		GameObject cube0 = patternCubes[0];
		GameObject cube1 = patternCubes[1];
		if (!waiting) {
					Debug.Log("First cube glowing");

		cube0.GetComponent<Glow>().GlowTheCubes();

		}

		StartCoroutine(Wait());
				Debug.Log("I'm ready to execute the next step");

		if (!waiting)
		{
		Debug.Log("Second cube glowing");
		cube1.GetComponent<Glow>().GlowTheCubes();

		}

	}

    IEnumerator Wait()
    {	
		waiting = true;
		while (waiting)
		{
			Debug.Log("Waiting for " + 2.0f + " seconds");
        	yield return new WaitForSeconds(2.0f);
			Debug.Log("Finished waiting");
			waiting = false;
		}
		
    }

}
