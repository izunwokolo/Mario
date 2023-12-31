using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour {
	// Movement Properties
	public float moveSpeed = 15;
	[Range(0,1)] public float sliding = 0.9f;
	public float jumpForce = 1200;
	public Text countText;
	public static int count = 0;
	
	bool IsGrounded() {
		// noobuts.com isGrounded function	
		// Get Bounds and Cast Range (10% of height)
		Bounds bounds = GetComponent<Collider2D>().bounds;
		float range = bounds.size.y * 0.1f;
		
		// Calculate a position slightly below the collider
		Vector2 v = new Vector2(bounds.center.x, 
								bounds.min.y - range);
		// Linecast upwards
		RaycastHit2D hit = Physics2D.Linecast(v, bounds.center);
		
		// Was there something in-between, or did we hit ourself?
		return (hit.collider.gameObject != gameObject);	
	}
 void OnTriggerEnter2D(Collider2D col)
 {
 if (col.gameObject.tag == "coin")
 {
 count = count + 1; 
 SetCountText(); 
    }
 }
 void OnCollisionEnter2D(Collision2D coll){
 
 if (coll.gameObject.tag == "pipe")
	 
	 	SceneManager.LoadScene(sceneName: "Level 2 Mario");
		
		if (coll.gameObject.tag == "me")
	 
	 	SceneManager.LoadScene(sceneName: "Level 3 Mario");
		
		if (coll.gameObject.tag == "end")
	 
	 	SceneManager.LoadScene(sceneName: "You Win");
		
		
		
		}
	
	void FixedUpdate () {
		// Horizontal Movement
		float h = Input.GetAxis("Horizontal");
		Vector2 v = GetComponent<Rigidbody2D>().velocity;
		if (h != 0) {
			// Move Left/Right
			GetComponent<Rigidbody2D>().velocity = new Vector2(h * moveSpeed,v.y);
			transform.localScale = new Vector2(Mathf.Sign(h),transform.localScale.y);
		} else {
			// Get slower (Super Mario style sliding motion)
			GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding,
			  v.y);
		}
		GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(h));
		
		// Vertical Movement (Jumping)
		bool grounded = IsGrounded();
		if(Input.GetKey(KeyCode.UpArrow) && grounded)
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
		GetComponent<Animator>().SetBool("Jumping", !grounded);
	}
	
	void SetCountText()
	{
		countText.text = count.ToString();
	}
}
	
