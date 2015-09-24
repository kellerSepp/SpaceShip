using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int _count;

	// Use this for initialization
	void Start ()
	{	
		rb = GetComponent<Rigidbody>();
		_count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		if (Application.platform == RuntimePlatform.Android) {
			
			//Vector3 movement = new Vector3 (Input.acceleration.x, 0, Input.acceleration.z);
			Vector3 dir = new Vector3();
			dir.x = -Input.acceleration.y;
			dir.z = Input.acceleration.x;
			if (dir.sqrMagnitude > 1)
				dir.Normalize();
			rb.AddForce (dir * speed);
			return;
		} else {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
		
			Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		
			rb.AddForce (movement * speed);
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive(false);
			_count++;
			SetCountText();
		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + _count.ToString ();
		if(_count >= 8)
			winText.text = "You Win!";
	}
}