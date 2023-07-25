using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
   public Transform target;
   public float cameraDistance = 30.0f;
   
   void Awake ()
   {
   	GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
   }
   
   void FixedUpdate ()
   {
   	transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	
   }
}