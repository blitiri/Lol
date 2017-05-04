using UnityEngine;
using System.Collections;

public abstract class AutoAttack : ScriptableObject {

	protected GameObject player;

	public abstract void OnAutoAttack ();
	public void SetPlayer(GameObject player){
		this.player = player;
	}


}

