using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public string state;
	public float turnSmoothing = 12.5f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;

	//booleans button presses
	private bool Jump;

	private Vector3 moveVec = Vector3.zero;

	// Use this for initialization
	void Awake () {
		//animation.Play("walk");

	}

	// Update is called once per frame
	void Update () {
		//get input
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		//Jump = Input.GetKeyDown ("Jump");

		//checkBut ();
		setState (h, v);//this also calls the rot function

		//select state depending on input

		//checkBut ();

		animate ();



		//animation.Play("walk");
	}



	void setState(float h, float v)
	{
		Vector3 camVec = GameObject.FindGameObjectWithTag ("MainCamera").transform.forward;
		camVec.y = 0f;
		camVec.Normalize ();
		
		Vector3 camVec2 = GameObject.FindGameObjectWithTag ("MainCamera").transform.right;
		camVec2.y = 0f;
		camVec2.Normalize ();

		//select a state based on the numbers
		if ((h == 0f) && (v == 0f))
		{
			state = "idle";
		}
		else if((h != 0f) || (v!=0f))
		{
			state = "run";
			
			if(v != 0)
			{
				if(h != 0)
				{
					moveVec = ((camVec * v) + (camVec2 * h)) * Time.deltaTime;
				}
				else
				{
					moveVec = camVec * v * Time.deltaTime;
				}
			}
			else if(h != 0)
			{
				moveVec = camVec2 * h * Time.deltaTime;
			}
		}
		Rotating(moveVec);

	}

	void checkBut()
	{
		Jump = Input.GetKey ("Jump");
	}

	void Rotating (Vector3 moveVec)
	{
		// Create a new vector of the horizontal and vertical inputs.
		//Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(moveVec, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
	}

	void RotatingD ()
	{
		Vector3 camVec = GameObject.FindGameObjectWithTag ("MainCamera").transform.forward;
		camVec.y = 0;
		camVec.x *= -1;
		camVec.z *= -1;
		// Create a new vector of the horizontal and vertical inputs.
		//Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(camVec, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
	}

	void animate()
	{
		if (state == "walk") {
						animation.Play ("walk");
				} else if (state == "idle") {
						animation.Play ("idle");
				} else if (state == "run") {
						animation.Play ("run");
				} else if (state == "stand") {
						animation.Play ("stand");
				} 
		if (Jump == true) {
					animation.Play ("jump");
				}


	}
}



