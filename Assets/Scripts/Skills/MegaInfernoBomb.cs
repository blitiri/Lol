using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class MegaInfernoBomb : Abilities {
<<<<<<< HEAD

	public GameObject megaBombPrefab;
	public Transform playerPosition;
	public Transform finalPosition;
	public float journeyTime=1.0f;



	public override void OnAbilityActivation()
	{
		GameObject ball = Instantiate(megaBombPrefab, playerPosition.position, Quaternion.identity)as GameObject;
		ball.transform.position = Vector3.Slerp (playerPosition.position, finalPosition.position, journeyTime);
=======
	public override void OnAbilityActivation(){
		
>>>>>>> 3ba5d2fb585a30ecef15cb894239a174d958a215
	}
}