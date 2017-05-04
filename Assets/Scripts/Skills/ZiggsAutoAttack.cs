using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class ZiggsAutoAttack : AutoAttack {
	public float maxCastRange;
	public GameObject autoattackPrefab;

	private Ray cameraRay;
	private RaycastHit hit;
	private Plane playerPlane;
	private float hitdist;

	[HideInInspector]
	public Vector3 targetPoint;

	public float attackDamage;
	public float attackSpeed;
	

	public override void OnAutoAttack(){
		playerPlane = new Plane (Vector3.up, GameManager.instance.player.transform.position);
		cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (playerPlane.Raycast (cameraRay, out hitdist)) {
			targetPoint = cameraRay.GetPoint (hitdist);
		}
		Debug.Log ("Clicked!");

		Debug.DrawRay (Camera.main.transform.position, cameraRay.direction * Vector3.Distance (Camera.main.transform.position, targetPoint), Color.red);
		Vector3 dist = targetPoint - GameManager.instance.player.transform.position;
		if (dist.magnitude < maxCastRange) {
			GameObject satchel = Instantiate (autoattackPrefab, GameManager.instance.player.transform.position + new Vector3 (0, 1.5f, 0.5f), Quaternion.identity) as GameObject;
		}
	}
}
