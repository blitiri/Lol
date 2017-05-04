using UnityEngine;
using System.Collections;

public class HexplosiveMinefieldBehaviour : MonoBehaviour {
	public HexplosiveMinefield minefieldStats;
	private float skillDurationTimer;

	private bool canDetonate;
	// Use this for initialization
	void Start () {
		canDetonate = false;
	}

	// Update is called once per frame
	void Update () {
		skillDurationTimer += Time.deltaTime;
		StartCoroutine (BallSlerp ());
		canDetonate = true;
	}

	IEnumerator BallSlerp(){
		transform.position = Vector3.Slerp (transform.position, minefieldStats.targetPoint, minefieldStats.arcSpeed * Time.deltaTime);

		if (skillDurationTimer > minefieldStats.skillDuration) {
			Destroy (this.gameObject);
		}
		yield return null;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy" && canDetonate) {
			//			other.gameObject.GetComponent<Rigidbody> ().transform.Translate (other.transform.forward * -satchelStats.bounceStrenght * Time.deltaTime);
			Destroy (this.gameObject);
		} else {
			GameObject mines = Instantiate (minefieldStats.minefieldPrefab, minefieldStats.targetPoint, Quaternion.identity) as GameObject;
			Destroy (this.gameObject);
		}

	}
}
