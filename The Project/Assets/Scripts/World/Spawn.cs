using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	private GameObject gameobject;
	private Vector3 location;
	private int xAxis;
	private int zAxis;
	public int spawnSquare;
	private int spawnAmount;

	void Start ()
	{
		spawnAmount = 0;
		gameobject = new GameObject ("wolf - instance");
	}
	
	void Update ()
	{
		gameobject = GameObject.FindGameObjectWithTag ("Wolf");
		xAxis = Random.Range((int)transform.position.x - spawnSquare/2, (int)transform.position.x + spawnSquare/2);
		zAxis = Random.Range((int)transform.position.z - spawnSquare/2, (int)transform.position.z + spawnSquare/2);
		
		location.Set(xAxis, transform.position.y, zAxis);

		if (spawnAmount < Logic.wolfCap)
		{
			spawn ();
		}
	}

	void spawn ()
	{
		Instantiate(gameobject, location, transform.rotation);
		spawnAmount += 1;
	}
}