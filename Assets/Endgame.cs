using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour {

// Start is called befor the first frame update
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnCollisionEnter2D(Collision2D coll)
	      {
		  
		  if(coll.gameObject.tag== "Player"){
		  //Restart
	Application.LoadLevel(Application.loadedLevel);
	
	}

	}
}
