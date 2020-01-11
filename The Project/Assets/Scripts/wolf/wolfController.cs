using UnityEngine;
using System.Collections;

public class wolfController : MonoBehaviour {

	// Use this for initialization
	public enum wolfState {wander,playerFound,dead,attack,alert,idle};//dead is for when no movement is to be applied
	public wolfState currentState;

	public bool canAttack;
	
	public float turnSmoothing = 3.5f;
	public float speed = 3f;

	//needed compenets
	wolfAnimation wolfanim;


	void Start () {
		wolfanim = GetComponent<wolfAnimation> ();
		currentState = wolfState.idle;
	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponentInChildren<wolfCanAttack>().canAttack) {
						currentState = wolfState.attack;
				}


		switch(currentState)
		{
		case wolfState.wander:
			wolfanim.wolfState = wolfAnimation.State.walk;
			break;

		case wolfState.playerFound:
			wolfanim.wolfState = wolfAnimation.State.run;
			if(animation.IsPlaying("run"))
			{
				Vector3 tempVec = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
				tempVec.Normalize();

				// Create a rotation based on this new vector assuming that up is the global y axis.
				Quaternion targetRotation = Quaternion.LookRotation(tempVec, Vector3.up);
				
				// Create a rotation that is an increment closer to the target rotation from the player's rotation.
				Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
				
				// Change the players rotation to this new rotation.
				rigidbody.MoveRotation(newRotation);
				transform.position += tempVec * speed * Time.deltaTime;
			}
			break;

		case wolfState.dead:
			wolfanim.wolfState = wolfAnimation.State.dead;
			//Desctroy(gameObjects);
			break;

		case wolfState.attack:
			wolfanim.wolfState = wolfAnimation.State.standBite;
			break;

		case wolfState.alert:
			wolfanim.wolfState = wolfAnimation.State.howl;
			break;

		case wolfState.idle:
			wolfanim.wolfState = wolfAnimation.State.idleLookAround;
			break;

		default:
			wolfanim.wolfState = wolfAnimation.State.idleLookAround;
			break;
	}
}
	void wolfattack(bool att)
	{
		canAttack = att;
		}
}
