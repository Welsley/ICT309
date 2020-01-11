using UnityEngine;
using System.Collections;

public class Quest_Giver_2 : MonoBehaviour {

	private GameObject player;
	private PlayerInventory playerinventory;
	private PlayerHUD playerhud;
	private PlayerHealth playerhealth;
	//private GUI gui;
	private bool healthAdded;
	private const int GOAL = 25;
	
	
	
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
			if(playerinventory.quest1)
			{
				if (playerinventory.appleCount >= GOAL) {
					//chat = "Oh You have enough apples, i'll take those off your hands please head to the next village";
					playerinventory.appleCount -= GOAL;
					playerinventory.quest2 = true;
				} else if(!playerinventory.quest2) {
					playerhud.chat = "Ah you, Hero boy. Would you be so kind\nas to deliver 25 apples for us?";
					Logic.appleCap = 32;
					Logic.wolfCap = 19;
				}
				if(playerinventory.quest2)
				{
					playerhud.chat = "Thanks for the apples,\nplease head to the last village";
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
			playerhealth.playerHealth += 75;
		}
		healthAdded = true;
	}
}