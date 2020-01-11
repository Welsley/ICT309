using UnityEngine;
using System.Collections;

public class CameraIdle : MonoBehaviour {
	public float Speed;
	public float MoveAmount;
	private Vector3 moveVec;
	private Vector3 moveVec2;
	private Vector3 tempVec;
	private bool tempBool;
	// Use this for initialization
	void Start () {
		moveVec = transform.position;
		moveVec.y -= MoveAmount;
		moveVec2 = transform.position;
		moveVec2.y += MoveAmount;
		tempVec = Vector3.zero;
		transform.position = moveVec;
		tempBool = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= moveVec.y * 1.1f)
		{
			//transform.position.y = moveVec.y * 1.25f;
			tempBool = true;
		}
		else if (transform.position.y > moveVec2.y * 0.9f)
		{
			//transform.position.y = moveVec2.y * 0.75f;
			tempBool = false;
		}

		if (tempBool)
		{
			tempVec = Vector3.Lerp (transform.position, moveVec2, Speed * Time.deltaTime);
		}
		else
		{
			tempVec = Vector3.Lerp (transform.position, moveVec, Speed * Time.deltaTime);
		}

		transform.position = (tempVec);
	}
}
