using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public Transform ballSpawnTransform;
	public float ballForce;

	public override void OnAbilityActivation(){
		GameObject ball = Instantiate (ballPrefab) as GameObject;
		ball.transform.position = ballSpawnTransform.position;
		ball.transform.rotation = ballPrefab.transform.rotation;
		ball.GetComponent<Rigidbody> ().AddForce (ballSpawnTransform.forward * ballForce * Time.deltaTime, ForceMode.Impulse);
	}


}
