using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float move = 4f;
	private Vector3 moveVec = Vector3.zero;

	//public float x;
	//public float z;
	//public float turnSmoothing = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");



		if ((h != 0f) || (v != 0f))
						movefunc (h, v); 


		//transform.Translate(Vector3.forward * h);

	}

	//movement
	void movefunc(float h, float v)
	{
		/*
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		*/

		Vector3 camVec = GameObject.FindGameObjectWithTag ("MainCamera").transform.forward;
		camVec.y = 0f;
		camVec.Normalize ();

		Vector3 camVec2 = GameObject.FindGameObjectWithTag ("MainCamera").transform.right;
		camVec2.y = 0f;
		camVec2.Normalize ();

		/*
		x = h * move  * Time.deltaTime;
		z = v * move * Time.deltaTime;
		*/

		if(v != 0)
		{
			if(h != 0)
			{
				Vector3 tempVec = (camVec * v + camVec2 * h);
				tempVec.Normalize();
				moveVec = tempVec * move * Time.deltaTime;
			}
			else
			{
				moveVec = camVec * v * move  * Time.deltaTime;
			}
		}
		else if(h != 0)
		{
			moveVec = camVec2 * h * move * Time.deltaTime;
		}

		/*if (h > 0) {
						//transform.Translate (Vector3.forward * h);
				} else {
				//x=x*-1;
				}
				
		if (z > 0) {
				} else
						z = z * -1;*/
		//Vector3 lo = Vector3 (-1, 0, 0);
		transform.position += (moveVec);
		//transform.Translate (camVec2);


		//gameObject.transform.Translate(x, 0, z);
		//transform.Translate(0, 0, z);
		//transform.Translate (x, 0, 0);

		//transform.position = new Vector3 (x, 0, z);
	}



}
