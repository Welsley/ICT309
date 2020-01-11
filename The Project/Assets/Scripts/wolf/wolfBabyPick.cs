using UnityEngine;
using System.Collections;

public class wolfBabyPick : MonoBehaviour {

	private GameObject player;
	private PlayerInventory playerInventory;
	private PlayerHealth playerHealth;

	void Awake(){
				player = GameObject.FindGameObjectWithTag ("Player");
				playerInventory = player.GetComponent<PlayerInventory> ();
				playerHealth = player.GetComponent<PlayerHealth> ();
		}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInventory.wolfCount +=1;
			playerHealth.playerHealth += 250;
			Destroy(gameObject);
		}
	}
}
