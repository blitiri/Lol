using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public GameObject ballSpawnTransform;
	public float ballForce;

	public override void OnAbilityActivation(){
		GameObject ball = Instantiate (ballPrefab) as GameObject;
		ball.transform.position = ballSpawnTransform.transform.position;
		ball.transform.rotation = ballPrefab.transform.rotation;
		ball.GetComponent<Rigidbody> ().AddForce (ballSpawnTransform.transform.forward * ballForce * Time.deltaTime, ForceMode.Impulse);
	}


}
