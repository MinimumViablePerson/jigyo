using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour {

	public BaseHero hero;

	public enum TurnState
	{
		PROCESSING,
		ADDTOLIST,
		WAITING,
		SELECTING,
		ACTION,
		DEAD
	}

	public TurnState currentState;


	//for the ProgressBar
	public Image progressBar;
	private float currentCooldown = 0f;
	private float maximumCooldown = 5f;

	// Use this for initialization
	void Start () {
		currentState = TurnState.PROCESSING;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (currentState);
		switch (currentState)
		{
		case (TurnState.PROCESSING):
			UpdateProgressBar ();
		break;
		case (TurnState.ADDTOLIST):
		break;
		case (TurnState.WAITING):
		break;
		case (TurnState.SELECTING):
		break;
		case (TurnState.ACTION):
		break;
		case (TurnState.DEAD):
		break;
		}
	}

	void UpdateProgressBar ()
	{	
		currentCooldown = currentCooldown + Time.deltaTime;
		float calcCooldown = currentCooldown / maximumCooldown;
		progressBar.transform.localScale = new Vector2 (Mathf.Clamp (calcCooldown, 0, 1), progressBar.transform.localScale.y);
		if (currentCooldown >= maximumCooldown)
		{
			currentState = TurnState.ADDTOLIST;
		}
	}
}
