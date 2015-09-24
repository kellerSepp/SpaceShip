using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	public float speed;


	Vector3 movement;
	Rigidbody playerRigidbody;


	// Use this for initialization
	void Start () 
	{
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h,v);

	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition (transform.position + movement);
	}


	void Look()
	{

	}
}
