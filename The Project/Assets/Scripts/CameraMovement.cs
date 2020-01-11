using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	//variables
	Transform target;
	float distance = 3.0f;
	float height = 3.0f;
	float damping = 5.0f;
	bool smoothRotation = true;
	float rotationDamping = 10.0f;
	
	void Update () {
		var wantedPosition = target.TransformPoint(0, height, -distance);
		transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		
		if (smoothRotation) {
			var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		
		else transform.LookAt (target, target.up);
	}
	/*public GameObject target;

	private float distanceAway;
	private float distanceUp;
	private float smooth;
	private Transform follow;
	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		follow = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LateUpdate()
	{
		targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
		//Debug.DrawRay (follow.position, Vector3.up * distanceUp, Color.red);
		//Debug.DrawRay (follow.position, -1f * follow.forward * distanceAway, Color.blue);
		//Debug.DrawLine (follow.position, targetPosition, Color.magenta);
		
		//make a smooth transition between its current position and the position it wants to be
		transform.position = Vector3.Lerp (transform.position, targetPosition, Time.deltaTime * smooth);
		
		//make camera look the right way
		transform.LookAt(target.transform);
		//transform.Translate (follow.position.x, 0, follow.position.z);
	}*/
}
