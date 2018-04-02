using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBrain : MonoBehaviour
{
    float timeBetweenCubes = 2.0f; // Time between each cube glowing
	bool waiting = false;
    public List<GameObject> allCubes = new List<GameObject>(); // List to store all the cubes in the scene
    public List<GameObject> patternCubes = new List<GameObject>(); // Cubes in the pattern

    public int cubeNumber = 0;

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
        int numberOfCubes = 4; // Set it to 4 for testing

        for (int i = 0; i < numberOfCubes; i++)
        {
            int randomNumber = Random.Range(0, allCubes.Count);

            while(patternCubes.Contains(allCubes[randomNumber]))
            {
                randomNumber = Random.Range(0, allCubes.Count);
            }

            patternCubes.Add(allCubes[randomNumber]);
        }
        
    }

    void Start()
    {
        FindAllCubes();
        CubesInPattern();
		GlowCubes();
    }

	void GlowCubes()
	{
		StartCoroutine(WaitToGlow(cubeNumber));
	}

    void Glow() 
    {
        Debug.Log(patternCubes[cubeNumber].name + " is glowing");
        patternCubes[cubeNumber].GetComponent<Glow>().GlowTheCubes();
        cubeNumber++;
        if (cubeNumber < 4) {
            GlowCubes();
        } else {
            Debug.Log("Finished glowing pattern");
        }
    }

    IEnumerator WaitToGlow(int cubeNumber)
    {	
        yield return new WaitForSeconds(timeBetweenCubes);
        Glow();
		waiting = true;
    }


    // JUST FOR TESTING the answer part of the mini-challenge
    public void ButtonClick(){
        patternCubes[0].GetComponent<Glow>().GlowTheCubes();
    }
}
