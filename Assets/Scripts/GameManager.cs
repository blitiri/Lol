using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject player;
	public Transform playerSpawn;
	private GameObject selectedObject;

	void Awake() {
		instance = this;
		player = Instantiate (player, playerSpawn.position, player.transform.rotation) as GameObject;
		selectedObject = player;
	}
		
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getSelectedObject() {
		return selectedObject;
	}
}
