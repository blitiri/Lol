using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;
	private Vector3 targetPoint;
	public float movementSpeed;

	public Abilities ability1;
	public Abilities ability2;
	public Abilities ability3;
	public Abilities ability4;
	public AutoAttack autoAttack;

	public float qSkillCooldown;
	public float wSkillCooldown;
	public float eSkillCooldown;
	public float rSkillCooldown;

	[HideInInspector]
	public bool qIsOnCooldown;
	[HideInInspector]
	public bool wIsOnCooldown;
	[HideInInspector]
	public bool eIsOnCooldown;
	[HideInInspector]
	public bool rIsOnCooldown;

	[HideInInspector]
	public bool canMove;
	// Use this for initialization
	void Start () {
		canMove = true;
		targetPoint = transform.position;
		InitAbility (ability1);
		InitAbility (ability2);
		InitAbility (ability3);
		InitAbility (ability4);
	}
	
	// Update is called once per frame
	void Update () {
		CharacterMovement ();
		if (!qIsOnCooldown) {
			StartCoroutine (qSkillActivation ());
		}

		if (!wIsOnCooldown) {
			StartCoroutine (wSkillActivation ());
		}

		if (!eIsOnCooldown) {
			StartCoroutine (eSkillActivation ());
		}

		if (!rIsOnCooldown) {
			StartCoroutine (rSkillActivation ());
		}

		AutoAttack ();
	}

	public void CharacterMovement(){
		if (canMove) {
			if (Input.GetMouseButtonDown (1) && GUIUtility.hotControl == 0) {  
				playerPlane = new Plane (Vector3.up, transform.position);
				cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

				if (playerPlane.Raycast (cameraRay, out hitdist)) {
					targetPoint = cameraRay.GetPoint (hitdist);
				}
				Debug.Log ("Clicked!");
			}
			Debug.DrawRay (Camera.main.transform.position, cameraRay.direction * Vector3.Distance (Camera.main.transform.position, transform.position), Color.green);
		
			transform.position = Vector3.MoveTowards (transform.position, targetPoint, movementSpeed * Time.deltaTime);
			transform.LookAt (targetPoint);
		}
	}

	IEnumerator qSkillActivation(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			ability1.OnAbilityActivation ();
			qIsOnCooldown = true;
			UIManager.instance.qButton.defaultColor = Color.red;
			yield return new WaitForSeconds (qSkillCooldown);
			UIManager.instance.qButton.defaultColor = Color.grey;
			qIsOnCooldown = false;
		}
	}

	IEnumerator wSkillActivation(){
		if (Input.GetKeyDown (KeyCode.W)) {
			ability2.OnAbilityActivation ();
			wIsOnCooldown = true;
			UIManager.instance.wButton.defaultColor = Color.red;
			yield return new WaitForSeconds (wSkillCooldown);
			UIManager.instance.wButton.defaultColor = Color.grey;
			wIsOnCooldown = false;
		} 

	}

	IEnumerator eSkillActivation(){
		if (Input.GetKeyDown (KeyCode.E)) {
			ability3.OnAbilityActivation ();
			eIsOnCooldown = true;
			UIManager.instance.eButton.defaultColor = Color.red;
			yield return new WaitForSeconds (eSkillCooldown);
			UIManager.instance.eButton.defaultColor = Color.grey;
			eIsOnCooldown = false;
		} 

	}

	IEnumerator rSkillActivation(){
		if (Input.GetKeyDown (KeyCode.R)) {
			ability4.OnAbilityActivation ();
			rIsOnCooldown = true;
			UIManager.instance.rButton.defaultColor = Color.red;
			yield return new WaitForSeconds (rSkillCooldown);
			UIManager.instance.rButton.defaultColor = Color.grey;
			rIsOnCooldown = false;
		} 

	}

	private void InitAbility(Abilities ability){
		if (ability != null) {
			ability.SetPlayer (gameObject);
		}

	}

	private void AutoAttack(){
		//Insert autoattack condition
		autoAttack.OnAutoAttack ();
	}
}
