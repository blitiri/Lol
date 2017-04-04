using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public GameObject ballSpawnTransform;
	public float ballForce;

	public override void OnAbilityActivation(){
		GameObject ball = Instantiate (ballPrefab) as GameObject;
<<<<<<< HEAD
		ball.transform.position = ballSpawnTransform.position;
=======
		ball.transform.position = ballSpawnTransform.transform.position;
>>>>>>> 3ba5d2fb585a30ecef15cb894239a174d958a215
		ball.transform.rotation = ballPrefab.transform.rotation;
		ball.GetComponent<Rigidbody> ().AddForce (ballSpawnTransform.transform.forward * ballForce * Time.deltaTime, ForceMode.Impulse);
	}


}
