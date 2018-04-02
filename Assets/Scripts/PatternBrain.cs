using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBrain : MonoBehaviour
{
    float timeBetweenCubes = 1.0f; // Time between each cube glowing
	bool waiting = false;
    public List<GameObject> allCubes = new List<GameObject>(); // List to store all the cubes in the scene
    public List<GameObject> patternCubes = new List<GameObject>(); // Cubes in the pattern
    public List<GameObject> answerCubes = new List<GameObject>(); // To store the cubes that the user clicks
    public List<GameObject> buttons = new List<GameObject>(); // Buttons in scene

    public string answer = ""; // Answer in a string format
    public string guess = "";
    public int cubeNumber = 0;

    int clickNumber = 0;

    void Start()
    {
         foreach (GameObject buttonObj in GameObject.FindGameObjectsWithTag("ColorButton"))   // Finding all buttons
        {
            buttons.Add(buttonObj);
        }
        DisableButtons();
        FindCubes();
        CubesInPattern();
		GlowCubes();
    }

    // Find all cubes in the scene
     void FindCubes()
    {
        foreach (GameObject cubeObj in GameObject.FindGameObjectsWithTag("ColorCube"))
        {
            allCubes.Add(cubeObj);
        }
    }

    // Find all colour buttons and disable them
    void DisableButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    void ActivateButtons()
    {
        // Activate all buttons on screen
        foreach(GameObject btn in buttons)
        {
            btn.SetActive(true);
        }
    }

    // Randomly pick a varying number of cubes
    void CubesInPattern()
    {
        int numberOfCubes = 4; // Set it to 4 for testing

        for (int i = 0; i < numberOfCubes; i++)
        {
            patternCubes.Add(allCubes[Random.Range(0, allCubes.Count)]);
        }
        
    }

	void GlowCubes()
	{
		StartCoroutine(WaitToGlow(cubeNumber));
	}

    void Glow() 
    {
        // Debug.Log(patternCubes[cubeNumber].name + " is glowing");
        patternCubes[cubeNumber].GetComponent<Glow>().GlowCube();
        cubeNumber++;
        if (cubeNumber < 4) {
            GlowCubes();
        } else {
            Debug.Log("Finished glowing pattern");
            ActivateButtons();
            print("Cubes to answer: ");
            foreach(GameObject cube in patternCubes){
                answer = answer + cube.name.Split(' ')[0];
            }
            print(answer);
        }
    }

    IEnumerator WaitToGlow(int cubeNumber)
    {	
        yield return new WaitForSeconds(timeBetweenCubes);
        Glow();
		waiting = true;
    }

    public void ButtonClick(GameObject btn){
        clickNumber++;
        string color = btn.name.Split(' ')[0];
        GameObject cube = GameObject.Find(color + " Cube");
        cube.GetComponent<Glow>().GlowCube();
        if (clickNumber == 4)
        {
            answerCubes.Add(cube);
            Debug.Log("Max Cubes Reached");
            DisableButtons();
            CheckAnswer();
        }
        answerCubes.Add(cube);
    }

    void CheckAnswer()
    {
        bool isCorrect = true;
        for(int i=0; i < 4; i++ )
        {
            if (answerCubes[i].name != patternCubes[i].name)
            {
                isCorrect = false;
                break;
            }
        }
        Debug.Log("Your guess is " + isCorrect);
    }
}
