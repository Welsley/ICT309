using UnityEngine;
using System.Collections;

public class Quest_Giver_1 : MonoBehaviour {

	private GameObject player;
	private PlayerInventory playerinventory;
	private PlayerHUD playerhud;
	private PlayerHealth playerhealth;
	//private GUI gui;

	bool firstChat;
	private bool healthAdded;
	private const int GOAL = 15;



	// Use this for initialization
	void Awake () {
		firstChat = false;
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
		if (other.gameObject == player)
		{
			if (!firstChat)
			{
				playerhud.chat = "Please us collect apples for the\nvillage. Remeber, you promised!";
			}
			else if (playerinventory.appleCount >= GOAL)
			{
				playerinventory.appleCount -= GOAL;
				playerinventory.quest1 = true;
			}
			else if (!playerinventory.quest1)
			{
				playerhud.chat = "You don't have enough apples M8";
			}
			if(playerinventory.quest1)
			{
				playerhud.chat = "Thanks for the apples,\nplease head to the next village";
				addQuestHealth();
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		firstChat = true;
		playerhud.chat = "";
	}

	void addQuestHealth()
	{
		if (!healthAdded)
		{
			playerhealth.playerHealth += 50;
		}
		healthAdded = true;
	}
}
