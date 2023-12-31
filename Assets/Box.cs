using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {
	
	// The Curve
	public AnimationCurve curve;
	
	// The object to spawn
	public GameObject spawnPrefab;
	
	// The next box
	public GameObject nextPrefab;
	
	IEnumerator sample() {
		//start position
		Vector2 pos = transform.position;
		
		// go through curve time
		for (float t=0; t<curve.keys[curve.length-1].time; t+=Time.deltaTime) {
			// move a bit
			transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));
			
			// come back next Update
			yield return null;
		}
		
		// spawn an object if any
		if (spawnPrefab)
			Instantiate(spawnPrefab, transform.position + Vector3.up,
			  Quaternion.identity);
			  
		// spawn next one if any, destroy box
		if (nextPrefab)
			Instantiate(nextPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		 StartCoroutine("sample");
	}
}


