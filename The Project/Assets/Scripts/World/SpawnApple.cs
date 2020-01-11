using UnityEngine;
using System.Collections;

public class SpawnApple : MonoBehaviour
{
	private GameObject gameobject;
	private Vector3 location;
	private int xAxis;
	private int yAxis;
	private int zAxis;
	public int spawnSquare;
	private int spawnAmount;
	private GameObject player;
	private PlayerInventory playerInventory;
	private int oldAmount;
	
	void Start ()
	{
		spawnAmount = 0;
		gameobject = new GameObject ("apple - instance");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInventory = player.GetComponent<PlayerInventory> ();
		oldAmount = 0;
	}
	
	void Update ()
	{
		gameobject = GameObject.FindGameObjectWithTag ("Apple");
		xAxis = Random.Range((int)transform.position.x - spawnSquare/2, (int)transform.position.x + spawnSquare/2);
		yAxis = Random.Range((int)transform.position.y - (int)(spawnSquare/1.5), (int)transform.position.y + (int)(spawnSquare/1.5));
		zAxis = Random.Range((int)transform.position.z - spawnSquare/2, (int)transform.position.z + spawnSquare/2);
		
		location.Set(xAxis, yAxis, zAxis);
		
		if (spawnAmount < Logic.appleCap)
		{
			spawn ();
		}

		if (playerInventory.appleCount > oldAmount)
		{
			spawnAmount -= playerInventory.appleCount - oldAmount;
		}
		oldAmount = playerInventory.appleCount;
	}
	
	void spawn ()
	{
		Instantiate(gameobject, location, transform.rotation);
		spawnAmount += 1;
	}
}
