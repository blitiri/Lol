using UnityEngine;
using System.Collections;

public class SatchelChargeBehaviour : MonoBehaviour {
	public SatchelCharge satchelStats; 
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
		transform.position = Vector3.Slerp (transform.position, satchelStats.targetPoint, satchelStats.arcSpeed * Time.deltaTime);

		if (skillDurationTimer > satchelStats.skillDuration) {
			Destroy (this.gameObject);
		}
		yield return null;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy" && canDetonate) {
//			other.gameObject.GetComponent<Rigidbody> ().transform.Translate (other.transform.forward * -satchelStats.bounceStrenght * Time.deltaTime);
			Destroy (this.gameObject);
		}
	}
}
