using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public Transform ballSpawn;
	public float ballForce;



	public override void OnAbilityActivation(){
		GameObject ball = Instantiate (ballPrefab) as GameObject;
<<<<<<< HEAD


		ball.transform.position = ballSpawnTransform.transform.position;
		ball.transform.rotation = ballPrefab.transform.rotation;
		ball.GetComponent<Rigidbody> ().AddForce (ballSpawnTransform.transform.forward * ballForce * Time.deltaTime, ForceMode.Impulse);
=======
		ball.transform.position = ballSpawn.position;
>>>>>>> 747a62680cd2731a678f76e8b71d80f25bd38099
	}


}
