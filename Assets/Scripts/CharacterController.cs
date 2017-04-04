using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	public Camera mainCamera;
	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;
	private Vector3 targetPoint;
	public float movementSpeed;

	public Abilities ability1;
	public Abilities ability2;
	public Abilities ability3;
	public Abilities ability4;
	// Use this for initialization
	void Start () {
		targetPoint = transform.position;
		InitAbility (ability1);
		InitAbility (ability2);
		InitAbility (ability3);
		InitAbility (ability4);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterMovement ();
		SkillActivation ();
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

	public void SkillActivation(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			ability1.OnAbilityActivation ();

		}

		if (Input.GetKeyDown (KeyCode.W)) {
			ability2.OnAbilityActivation ();
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			ability3.OnAbilityActivation ();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			ability4.OnAbilityActivation ();
		}
	}

	private void InitAbility(Abilities ability){
		if (ability != null) {
			ability.SetPlayer (gameObject);
		}

	}
}
