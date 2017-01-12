using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {

	private BattleStateMachine BSM;
	public BaseEnemy enemy;

	public enum TurnState
	{
		PROCESSING,
		CHOOSEACTION,
		WAITING,
		ACTION,
		DEAD
	}

	public TurnState currentState;


	//for the ProgressBar
	private float currentCooldown = 0f;
	private float maximumCooldown = 5f;

	//starting position of this gameObject
	private Vector3 startPosition;

	//TimeForAction stuff
	private bool actionStarted = false;
	private GameObject HeroToAttack;

	// Use this for initialization
	void Start () {
		currentState = TurnState.PROCESSING;
		BSM = GameObject.Find ("BattleManager").GetComponent<BattleStateMachine> ();
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
		case (TurnState.CHOOSEACTION):
			ChooseAction ();
			currentState = TurnState.WAITING;
			break;
		case (TurnState.WAITING):
			break;
		case (TurnState.ACTION):
			StartCoroutine (TimeForAction ());
			break;
		case (TurnState.DEAD):
			break;
		}
	}

	void UpdateProgressBar ()
	{	
		currentCooldown = currentCooldown + Time.deltaTime;
		if (currentCooldown >= maximumCooldown)
		{
			currentState = TurnState.CHOOSEACTION;
		}
	}

	void ChooseAction()
	{
		HandleTurn myAttack = new HandleTurn ();
		myAttack.Attacker = enemy.name;
		myAttack.AttackerGameObject = this.gameObject;
		myAttack.TargetGameObject = BSM.HeroesInBattle[Random.Range(0, BSM.HeroesInBattle.Count)];
		BSM.CollectActions (myAttack);
	}

	private IEnumerator TimeForAction()
	{
		if (actionStarted)
		{
			yield break;
		}

		actionStarted = true;

		//animate the enemy
		Vector3 heroPosition = new Vector3(HeroToAttack.transform.position);
		while (MoveTowardsEnemy (heroPosition))
		{
			yield return null;
		}


		//wait a bit
		//do damage

		//animate back to starting position

		//remove this performer from the list in BSM

		//reset the BSM -> Wait

		actionStarted = false;

		//reset this enemy's state

		currentCooldown = 0f;
		currentState = TurnState.PROCESSING;
	}

	private bool MoveTowardsEnemy (Vector3 target)
	{
		
	}

}
