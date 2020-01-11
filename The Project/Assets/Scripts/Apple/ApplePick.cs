using UnityEngine;
using System.Collections;

public class ApplePick : MonoBehaviour {
	public int value;
	public int heal;
	private GameObject player;
	private PlayerInventory playerInventory;
	private PlayerHealth playerHealth;
	
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		heal = 1;
		value = 1;
		//onTriggerStay ();
		//print("Cool");
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		//print ("Cool2");
		if(other.gameObject == player)
		{
			//print ("Cool3");
			playerInventory.appleCount = playerInventory.appleCount +value;
			playerHealth.playerHealth += heal;
			Destroy(gameObject);
			
			//print(playerInventory.appleCount);
		}
	}
}