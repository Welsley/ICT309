using UnityEngine;
using System.Collections;

public class PlayerSave : MonoBehaviour {
	private GameObject[] savePoint;
	private GameObject player;
	private PlayerHealth playerhealth;
	private PlayerInventory playerinventory;
	private PlayerHUD playerhud;

	public Vector3 pos;
	public float health;
	public int apples;
	public int wolves;
	public bool quest1;
	public bool quest2;
	public bool quest3;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		savePoint = GameObject.FindGameObjectsWithTag ("Save");
		playerhealth = player.GetComponent<PlayerHealth> ();
		playerinventory = player.GetComponent<PlayerInventory> ();
		playerhud = player.GetComponent<PlayerHUD> ();
	}
	
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (transform.gameObject);
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == savePoint.GetValue(0) || other.gameObject == savePoint.GetValue(1) || other.gameObject == savePoint.GetValue(2))
		{
			playerhud.chat = "Checkpoint reached!";
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == savePoint.GetValue(0) || other.gameObject == savePoint.GetValue(1) || other.gameObject == savePoint.GetValue(2))
		{
			playerhud.chat = "";
			Save ();
		}
	}

	public void Save()
	{
		pos = transform.position;
		health = playerhealth.playerHealth;
		apples = playerinventory.appleCount;
		wolves = playerinventory.wolfCount;
		quest1 = playerinventory.quest1;
		quest2 = playerinventory.quest2;
		quest3 = playerinventory.quest3;
	}
}