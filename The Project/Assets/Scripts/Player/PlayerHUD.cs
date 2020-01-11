using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {

	public string chat;
	private GameObject player;
	private PlayerHealth playerhealth;
	private PlayerInventory playerinventory;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerhealth = player.GetComponent<PlayerHealth> ();
		playerinventory = player.GetComponent<PlayerInventory> ();
		chat = "";
	}
	
	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;
	}

	void OnGUI()
	{
		GUI.Box(new Rect (50, 50, 150, 175), "\nHealth: " + (int)playerhealth.playerHealth + "\nApples: " + playerinventory.appleCount + "\n\nQuests:\n\nVillage 1 saved: " + playerinventory.quest1.ToString() + "\nVillage 2 saved: " + playerinventory.quest2.ToString() + "\nVillage 3 saved: " + playerinventory.quest3.ToString());
		GUI.Box(new Rect (Screen.width/2 - Screen.width/8, Screen.height - 75, Screen.width/4, 50), chat);
	}
}