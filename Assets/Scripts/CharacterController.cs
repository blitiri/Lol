using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	public Camera mainCamera;
	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;
	private Vector3 targetPoint;
	public float movementSpeed;
	// Use this for initialization
	void Start () {
		targetPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterMovement ();
	}

	public void CharacterMovement(){
		if(Input.GetMouseButtonDown(1) && GUIUtility.hotControl == 0 ){  
			playerPlane = new Plane (Vector3.up, transform.position);
			cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);

			if (playerPlane.Raycast (cameraRay, out hitdist)) {
				targetPoint = cameraRay.GetPoint (hitdist);
			}
			Debug.Log ("Clicked!");
		}
		Debug.DrawRay (mainCamera.transform.position, cameraRay.direction * Vector3.Distance(mainCamera.transform.position,transform.position) , Color.green);
		
		transform.position = Vector3.MoveTowards (transform.position, targetPoint, movementSpeed * Time.deltaTime);
		transform.LookAt (targetPoint);
	}
}
