using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {
	public enum NPCState{idle}
	public NPCState currentState;
	// Use this for initialization
	void Start () {
		currentState = NPCState.idle;
	}
	
	// Update is called once per frame
	void Update () {
		animation.wrapMode = WrapMode.Once;
		switch (currentState) 
		{
		case NPCState.idle:
			animation.PlayQueued ("idle", QueueMode.CompleteOthers);
			break;
		default:
			break;
		}

	}
}
