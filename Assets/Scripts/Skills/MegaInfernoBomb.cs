using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class MegaInfernoBomb : Abilities {


	public GameObject megaBombPrefab;
	public Transform playerPosition;
	public Transform finalPosition;
	public float journeyTime=1.0f;
	public float maxCastRange;

	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;

	[HideInInspector]
	public Vector3 targetPoint;

	public override void OnAbilityActivation()
	{
		playerPlane = new Plane (Vector3.up, GameManager.instance.player.transform.position);
		cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (playerPlane.Raycast (cameraRay, out hitdist)) {
			targetPoint = cameraRay.GetPoint (hitdist);
		}
		Debug.Log ("Clicked!");

		Debug.DrawRay (Camera.main.transform.position, cameraRay.direction * Vector3.Distance (Camera.main.transform.position, targetPoint), Color.red);

		//area check
		Vector3 dist = targetPoint - GameManager.instance.player.transform.position;
		if (dist.magnitude < maxCastRange) {
			GameObject ball = Instantiate (megaBombPrefab, GameManager.instance.player.transform.position + new Vector3 (0, 1.5f, 0.5f), megaBombPrefab.transform.rotation) as GameObject;
			ball.GetComponent<Rigidbody> ().useGravity = false;
		}
	}

}