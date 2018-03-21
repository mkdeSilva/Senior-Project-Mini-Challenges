using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MathBrain : MonoBehaviour {

	public TMP_Text questionText;

	List<string> operations = new List<string>(new string[] {"add", "subtract", "multiply"});
	List<int> answerChoices = new List<int>();
	GameObject[] buttons;
	int answer = -101;


	void Start() 
	{
		buttons = GameObject.FindGameObjectsWithTag("AnswerButton");
		Question_Generator();
		Answer_Generator(answer);
		Populate_Answer_Buttons();

	}
	
	void Question_Generator() {
		string operation = operations[Random.Range(0, 3)]; // Randomly picking an operation from the list

		// Randomly choose 2 numbers
		int num1 = Random.Range(1,10);
		int num2 = Random.Range(1,10);;

		// Based on randomly chosen operation, perform the operation to the 2 numbers
		switch (operation)
		{
			case "add":
				answer = num1 + num2;
				Debug.Log(num1 + " + " + num2);
				questionText.text = num1 + " + " + num2 + " = ?";
				break;
			case "subtract":
				if (num1 > num2) {
					answer = num1 - num2;
					Debug.Log(num1 + " - " + num2);
					questionText.text = num1 + " - " + num2 + " = ?"; 
				} else {
					answer = num2 - num1;
					Debug.Log(num2 + " - " + num1);
					questionText.text = num2 + " - " + num1 + " = ?"; 
				}
				break;
			case "multiply":
				answer = num1 * num2;
				Debug.Log(num1 + " x " + num2);
				questionText.text = num1 + " x " + num2 + " = ?"; 
				break;
			default:
				Debug.Log("No operation chosen");
				break;
		}
		answerChoices.Add(answer);
		Debug.Log("Generated Question");
	}

	void Answer_Generator(int correctAnswer) // Generate a list of possible answers using the actual answer
	{
		int i = 0;
		while (i < 3) 
		{
			if (Random.Range(0,2) == 0) // To randomly choose between addition or subtraction 
			{
				// Add a random number to the answer
				answerChoices.Add(correctAnswer + Random.Range(1, 5));
			} 
			else
			{
				// Subtract a random number from the answer
				answerChoices.Add(correctAnswer - Random.Range(1, 5));
			}
			i++;
		}
		Debug.Log("Generated Answers");

	}

	void Populate_Answer_Buttons()
	{
		int i = 0;
		foreach (GameObject btn in buttons)
		{
			TMP_Text btnText = btn.GetComponent<Button>().GetComponentInChildren<TMP_Text>();
			btnText.text = answerChoices[i].ToString();
			i++;
			{
				
			}
		}
		Debug.Log("Populated Answer Buttons");
	}

	public void Check_Answer()
	{
		Debug.Log("you clicked me");
	}
}
