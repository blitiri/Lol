using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	private Transform ballSpawn;
	public float ballForce;



	public override void OnAbilityActivation()
    {
		GameObject ball = Instantiate (ballPrefab) as GameObject;
		ballSpawn = GameObject.Find ("ballSpawnTransform").transform;
		ball.transform.position = ballSpawn.position;
		ball.GetComponent<Rigidbody> ().AddForce (ballSpawn.forward * ballForce * Time.deltaTime, ForceMode.Impulse);
	}
}
