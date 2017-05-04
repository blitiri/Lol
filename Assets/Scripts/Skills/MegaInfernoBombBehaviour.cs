using UnityEngine;
using System.Collections;

public class MegaInfernoBombBehaviour : MonoBehaviour {
	public MegaInfernoBomb bombStats;

	public float journeyTime = 1.0F;
	private Vector3 center;
	private Vector3 startPosRelCenter;
	private Vector3 endPosRelCenter;
	private float startTime;

	void Start ()
	{
		center = (transform.position + bombStats.targetPoint) * 0.5F;
		center -= new Vector3 (0, 1, 0);
		startPosRelCenter = transform.position - center;
		endPosRelCenter = bombStats.targetPoint - center;
		startTime = Time.time;
	}
	// Update is called once per frame
	void Update ()
	{
		float fracComplete;
		fracComplete = (Time.time - startTime) / journeyTime;
		transform.position = Vector3.Slerp (startPosRelCenter, endPosRelCenter, fracComplete);
		transform.position += center;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			//Decrease life from enemy
			Destroy(this.gameObject);
		}
		if (collision.gameObject.tag != "Player") {
		Destroy (this.gameObject);
		}
	}
}
