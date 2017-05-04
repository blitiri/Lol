using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public float ballForce;
	public float maxSkillArea;
	public int maxBounces;
	public float maxCastRange;
	public float bounceAngle;
	public float arcSpeed;
	public float bounceTime;

	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;

	[HideInInspector]
	public Vector3 targetPoint;

	public override void OnAbilityActivation(){

		playerPlane = new Plane (Vector3.up, GameManager.instance.player.transform.position);
		cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (playerPlane.Raycast (cameraRay, out hitdist)) {
			targetPoint = cameraRay.GetPoint (hitdist);
		}
		Debug.Log ("Clicked!");

		Debug.DrawRay (Camera.main.transform.position, cameraRay.direction * Vector3.Distance (Camera.main.transform.position, targetPoint), Color.red);

		//Insert cooldown and area check
		Vector3 dist = targetPoint - GameManager.instance.player.transform.position;
		if (dist.magnitude < maxCastRange) {
			GameManager.instance.player.transform.LookAt(targetPoint); 
			GameObject ball = Instantiate (ballPrefab, GameManager.instance.player.transform.position + new Vector3 (0, 1.5f, 0.5f), GameManager.instance.player.transform.rotation) as GameObject;
			ball.GetComponent<Rigidbody> ().useGravity = false;
		}
	}
}
