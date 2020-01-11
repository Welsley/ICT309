using UnityEngine;
using System.Collections;

public class ToBoss : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel(2);
	}
}