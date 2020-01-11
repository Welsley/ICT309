using UnityEngine;
using System.Collections;

public class Quest_Giver_3 : MonoBehaviour {
	private GameObject player;
	private PlayerInventory playerinventory;
	private PlayerHUD playerhud;
	private PlayerHealth playerhealth;
	//private GUI gui;
	private bool healthAdded;
	private const int GOAL = 40;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerinventory = player.GetComponent<PlayerInventory> ();
		playerhud = player.GetComponent<PlayerHUD> ();
		playerhealth = player.GetComponent<PlayerHealth> ();
		healthAdded = false;
		//gui = GameObject.Instantiate
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
			if(playerinventory.quest1 && playerinventory.quest2)
			{
				if (playerinventory.appleCount >= GOAL)
				{
					playerinventory.appleCount -= GOAL;
					playerinventory.quest3 = true;
				}
				else if(!playerinventory.quest3)
				{
					playerhud.chat = "Beloved Hero! Please, help us collect a good\nsupply of apples! 40 Should suffice!";
					Logic.appleCap = 22;
					Logic.wolfCap = 24;
				}
				if(playerinventory.quest3)
				{
					playerhud.chat = "Many thanks for the apples!\nYou're a real Hero!";
					addQuestHealth();
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		playerhud.chat = "";
	}
	
	void addQuestHealth()
	{
		if (!healthAdded)
		{
			playerhealth.playerHealth += 100;
		}
		healthAdded = true;
	}
}
