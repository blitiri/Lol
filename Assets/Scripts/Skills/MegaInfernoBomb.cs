using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class MegaInfernoBomb : Abilities {

	public GameObject megaBombPrefab;
	public Transform playerPosition;
	public Transform finalPosition;
	public float journeyTime=1.0f;



	public override void OnAbilityActivation()
	{
		GameObject ball = Instantiate(megaBombPrefab, playerPosition.position, Quaternion.identity)as GameObject;
		ball.transform.position = Vector3.Slerp (playerPosition.position, finalPosition.position, journeyTime);
	}
}