using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class BouncingBomb : Abilities {
	public GameObject ballPrefab;
	public Transform ballSpawn;
	public float ballForce;



	public override void OnAbilityActivation(){
		GameObject ball = Instantiate (ballPrefab) as GameObject;
		ball.transform.position = ballSpawn.position;
	}


}
