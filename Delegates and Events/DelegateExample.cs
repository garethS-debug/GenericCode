using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample : MonoBehaviour {


	//executing methods in other scripts (Multicasting) 
	//----WARNING -------
	//resource leaks can happen with delegates 

	
	//DELEGATE
		//delegate with an int return type
		public delegate int MyTestDelegate(float valueToBeRounded);

		//creating an instance of the delegate. Points to the above delegate. Member variable
		private MyTestDelegate newtestDelegate;


	//EVENT
		//base upon which event is built (without it the event cant be built) 
		public delegate void UpdateInfoDelegate();
		//Accesser - return type is the delegate
		public static event UpdateInfoDelegate UpdateInfoEvent;
		internal static float timer = 0.0f;
		public float interval = 4.0f;
		//Another event example
		public static event MyTestDelegate ValueRoundingEvent;

	private void OnEnabled()
    {
		//In order for the delegate to run the method, it needs to be subscribed. 
		//Delegate Ref		//Method name no ()
		newtestDelegate = RoundTime;
		newtestDelegate = RoundMyAge;

		//both functions will be run 


    }

	//Same return type needed
	public int RoundTime(float valueRounded)
    {
		return Mathf.RoundToInt(valueRounded);
    }

	//Example of another method 
	public int RoundMyAge(float ageValue)
    {
		return Mathf.RoundToInt(ageValue);
	}

	private void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
        {

			//Calling Delegates
			Debug.Log("Rounded time value: " + newtestDelegate(Time.time));
			Debug.Log("Rounded age value: " + newtestDelegate(Random.Range(0,100)));
			
			//Calling event
			UpdateInfoEvent();
			ValueRoundingEvent(interval);

		}
    }


}
