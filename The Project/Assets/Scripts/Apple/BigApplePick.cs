using UnityEngine;
using System.Collections;

public class BigApplePick : MonoBehaviour {
	public int value;
	public int heal;
	private GameObject player;
	private PlayerInventory playerInventory;
	private PlayerHUD playerHud;
	private PlayerHealth playerHealth;
	
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory> ();
		playerHud = player.GetComponent<PlayerHUD> ();
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
			playerHud.chat = "congratulations!\n You have won!!!";
			playerHealth.playerHealth += heal;
			Destroy(gameObject);
			
			//print(playerInventory.appleCount);
		}
	}
}
