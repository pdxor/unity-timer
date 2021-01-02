using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
	public GameObject textDisplay;
	int secondsLeft = 60;
	public int minutesLeft = 10;
	public bool takingMinAway = false;
	public bool takingSecAway = false;
	void Start()
	{
			secondsLeft -= 1;
			minutesLeft -= 1;
			textDisplay.GetComponent<Text>().text = minutesLeft + ":"+ secondsLeft;
	
	}

	void Update()
	{

		if (takingSecAway == false && secondsLeft > 0)
		{
			StartCoroutine(secondTake());
		}  
		if (takingMinAway == false && minutesLeft > 0)
		{
			StartCoroutine(minuteTake());

		} 		

	}
	IEnumerator secondTake ()
	{
		takingSecAway = true;
		yield return new WaitForSeconds(1);
		secondsLeft -= 1;
		if (secondsLeft < 10){
			textDisplay.GetComponent<Text>().text = minutesLeft + ":0" + secondsLeft;
		} else {
		    textDisplay.GetComponent<Text>().text = minutesLeft + ":" + secondsLeft;	
		}

		takingSecAway = false;
	}

	IEnumerator minuteTake ()
	{
		takingMinAway = true;
		yield return new WaitForSeconds(60);
		minutesLeft -= 1;
		secondsLeft = 60; 
		takingMinAway = false;
	}	
}
