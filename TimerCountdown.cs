using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimerCountdown : MonoBehaviour
{
	public GameObject textDisplay;
	int secondsLeft = 60;
	public int minutesLeft = 10;
	public bool takingMinAway = false;
	public bool takingSecAway = false;
	public bool timersRunning = true;
	public UnityEvent endofTime;
 
    public void Invoke() {
        endofTime.Invoke();
    }
	void Start()
	{
			secondsLeft -= 1;
			minutesLeft -= 1;
			textDisplay.GetComponent<Text>().text = minutesLeft + ":"+ secondsLeft;
	
	}

	void Update()
	{
		if (timersRunning)
		{
			if (takingSecAway == false && secondsLeft > 0)
			{
				StartCoroutine(secondTake());
			} 
			if (takingMinAway == false && minutesLeft > 0)
			{
				StartCoroutine(minuteTake());
			} 		
			if(minutesLeft == 0 && secondsLeft == 0 ){
				Debug.Log("Out of time my friend");
				timersRunning = false;
			}
			if(minutesLeft < 1)
			{
				textDisplay.GetComponent<Text>().color = Color.red;			
			}
		} else {
			Invoke();
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
