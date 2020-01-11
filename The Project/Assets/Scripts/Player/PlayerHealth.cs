using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public float playerHealth;
	private GameObject player;
	private PlayerSave playerSave;
	private PlayerInventory playerInventory;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerSave = player.GetComponent<PlayerSave> ();
		playerInventory = player.GetComponent<PlayerInventory> ();
		playerHealth = 100;
	}

	void Update()
	{
		if (playerHealth <= 0f)
		{
			Respawn();
		}
		/*
		if (Application.loadedLevel == 2)
		{
			print ("was here");
		}
		 */
	}

	public void Respawn()
	{
		transform.position = playerSave.pos;
		playerInventory.appleCount = playerSave.apples;
		playerInventory.wolfCount = playerSave.wolves;
		playerInventory.quest1 = playerSave.quest1;
		playerInventory.quest2 = playerSave.quest2;
		playerInventory.quest3 = playerSave.quest3;
		playerHealth = playerSave.health;
	}
	/*
	void OnLevelWasLoaded(int level)
	{
		print ("was here");
		if (level == 2)
		{
			transform.position.Set (150f, 1000000f, 100f);
		}
	}
	*/
}