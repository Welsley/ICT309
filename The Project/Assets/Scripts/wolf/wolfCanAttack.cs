using UnityEngine;
using System.Collections;

public class wolfCanAttack : MonoBehaviour {
	private GameObject player;
	private GameObject wolf;
	private wolfController control;

	public bool canAttack;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		//wolf = GameObject.FindGameObjectWithTag("Wolf");//GetComponent<wolfController> ();
		//control = wolf.GetComponent<wolfController> ();
		canAttack = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
					canAttack = true;
			//gameObject.SendMessage(wolfattack,true, SendMessageOptions.DontRequireReceiver);
				}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			canAttack = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
				if (other.gameObject == player) {
						canAttack = false;
			//control.currentState = wolfController.wolfState.playerFound;
			//gameObject.SendMessage(wolfattack,false, SendMessageOptions.DontRequireReceiver);
				}
		}
}
