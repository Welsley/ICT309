using UnityEngine;
using System.Collections;

public class Spawn2 : MonoBehaviour
{
	private GameObject gameobject;
	private Vector3 location;
	private int xAxis;
	private int zAxis;
	public int spawnSquare;
	public int spawnAmount;
	private int spawned;
	
	void Start ()
	{
		gameobject = new GameObject ("wolf - instance");
		spawned = 0;
	}
	
	void Update ()
	{
		gameobject = GameObject.FindGameObjectWithTag ("Wolf");
		xAxis = Random.Range((int)transform.position.x - spawnSquare/2, (int)transform.position.x + spawnSquare/2);
		zAxis = Random.Range((int)transform.position.z - spawnSquare/2, (int)transform.position.z + spawnSquare/2);
		
		location.Set(xAxis, transform.position.y, zAxis);
		
		if (spawned < spawnAmount)
		{
			spawn ();
		}
	}
	
	void spawn ()
	{
		Instantiate(gameobject, location, transform.rotation);
		spawned ++;
	}
}
