using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class MegaInfernoBomb : Abilities
{
	public GameObject megaBombPrefab;
	public Transform megaBombSpawn;

	public override void OnAbilityActivation()
	{
		GameObject ball = Instantiate(megaBombPrefab)as GameObject;
        megaBombSpawn = GameObject.Find("megaBombSpawn").transform;
        ball.transform.position = megaBombSpawn.position;
	}
}