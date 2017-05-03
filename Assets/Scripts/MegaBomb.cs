using UnityEngine;
using System.Collections;

public class MegaBomb : MonoBehaviour
{
	public Transform endPos;
	//public float timeJourney = 0.01f;
	public float journeyTime = 1.0F;
	private Vector3 center;
	private Vector3 startPosRelCenter;
	private Vector3 endPosRelCenter;
	private float startTime;

	void Start ()
	{
		center = (transform.position + endPos.position) * 0.5F;
		center -= new Vector3 (0, 1, 0);
		startPosRelCenter = transform.position - center;
		endPosRelCenter = endPos.position - center;
		startTime = Time.time;
	}
	// Update is called once per frame
	void Update ()
	{
		float fracComplete;

		//transform.position = Vector3.Slerp(transform.position, endPos.position, timeJourney);
		fracComplete = (Time.time - startTime) / journeyTime;
		transform.position = Vector3.Slerp (startPosRelCenter, endPosRelCenter, fracComplete);
		transform.position += center;
	}
}
