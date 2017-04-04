using UnityEngine;
using System.Collections;

public abstract class Abilities : ScriptableObject {
<<<<<<< HEAD
	public abstract void OnAbilityActivation(MonoBehaviour caller);
=======
	protected GameObject player;

	public abstract void OnAbilityActivation();
	public void SetPlayer(GameObject player){
		this.player = player;
	}
>>>>>>> 747a62680cd2731a678f76e8b71d80f25bd38099
}
