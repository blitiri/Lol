using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameObject player;
	private GameObject selectedObject;

	void Awake() {
		instance = this;
		selectedObject = player;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getSelectedObject() {
		return selectedObject;
	}
}
