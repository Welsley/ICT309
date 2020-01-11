using UnityEngine;
using System.Collections;

public class wolfAnimation : MonoBehaviour {
	public enum State {idleLookAround,howl,walk,run,standBite,getHit,death,dead}
	private GameObject player;
	private PlayerHealth playerHealth;

	public State wolfState; 
	// Use this for initialization

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		wolfState = State.idleLookAround;
	}
	
	// Update is called once per frame
	void Update () {
		animation.wrapMode = WrapMode.Once;
		//switch case and things
		switch(wolfState)
		{
		case State.idleLookAround://the animation to idle
			if(!(animation.IsPlaying("howl") || animation.IsPlaying("standBite")))
			{
				animation.PlayQueued("idleLookAround", QueueMode.PlayNow);
			}
			else
			{
				animation.PlayQueued("idleLookAround", QueueMode.CompleteOthers);
			}
			break;

		case State.howl://animation to howel
			animation.PlayQueued ("howl", QueueMode.PlayNow);
			break;

		case State.walk:
			animation.PlayQueued ("walk", QueueMode.CompleteOthers);
			break;

		case State.run:
			if(!animation.IsPlaying("howl"))
			{
				if(animation.IsPlaying("walk") || animation.IsPlaying("idleLookAround"))
				{
					animation.PlayQueued("run", QueueMode.PlayNow);
				}
				else
				{
					animation.PlayQueued ("run", QueueMode.CompleteOthers);
				}
			}
			break;

		case State.standBite:
			animation.Play ("standBite");
			playerHealth.playerHealth -= 25f * Time.deltaTime;
			break;

		case State.getHit:
			animation.PlayQueued ("getHit", QueueMode.PlayNow);
			break;

		case State.death:
			animation.PlayQueued ("idleLookAround", QueueMode.PlayNow);
			animation.PlayQueued ("death", QueueMode.PlayNow);
			break;

		case State.dead:
			animation.PlayQueued ("dead", QueueMode.PlayNow);
			break;

		default:
			animation.Play ("idleNormal");
			break;
	}
}
}
