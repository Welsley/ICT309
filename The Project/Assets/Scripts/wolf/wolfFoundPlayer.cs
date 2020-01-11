using UnityEngine;
using System.Collections;

public class wolfFoundPlayer : MonoBehaviour {

	private GameObject player;
	//private PlayerInventory (store the hp or something
	private wolfController control;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		control = GetComponent<wolfController> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			control.currentState = wolfController.wolfState.alert;
			control.currentState = wolfController.wolfState.playerFound;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			control.currentState = wolfController.wolfState.playerFound;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			control.currentState = wolfController.wolfState.idle;
		}
	}
}

