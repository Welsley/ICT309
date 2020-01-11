using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	public int appleCount;
	public int wolfCount;

	public bool quest1;
	public bool quest2;
	public bool quest3;

	// Use this for initialization
	void Start () {
		appleCount = 0;
		wolfCount = 0;

		quest1 = false;
		quest2 = false;
		quest3 = false;

	}
	

}
