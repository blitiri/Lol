using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class HexplosiveMinefield : Abilities{
	public float maxCastRange;
	public GameObject projectilePrefab;
	public GameObject minefieldPrefab;

	private Ray cameraRay;
	private Plane playerPlane;
	private float hitdist;

	[HideInInspector]
	public Vector3 targetPoint;

	public float arcSpeed;
	public float skillDuration;
	public float bounceStrenght;

		public override void OnAbilityActivation(){
			playerPlane = new Plane (Vector3.up, GameManager.instance.player.transform.position);
			cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (playerPlane.Raycast (cameraRay, out hitdist)) {
				targetPoint = cameraRay.GetPoint (hitdist);
			}
			Debug.Log ("Clicked!");

			Debug.DrawRay (Camera.main.transform.position, cameraRay.direction * Vector3.Distance (Camera.main.transform.position, targetPoint), Color.red);
			Vector3 dist = targetPoint - GameManager.instance.player.transform.position;
			if (dist.magnitude < maxCastRange) {
			GameObject satchel = Instantiate (projectilePrefab, GameManager.instance.player.transform.position + new Vector3 (0, 1.5f, 0.5f), Quaternion.identity) as GameObject;
			}
	}
}
