using UnityEngine;
using System.Collections;

public class BouncingBombBehaviour : MonoBehaviour {
	/// <summary>
	/// The bomb stats.
	/// </summary>
	public BouncingBomb bombStats; 

	private float collisionCounter;
	private Rigidbody rb;
	private MeshRenderer ballMeshRenderer;

	private Ray playerRay;
	private Plane playerPlane;
	private float hitdist;

	private bool playerCanMove;

	private Vector3 mousePos;
	private Vector3 dist;

	private float startTime;
	private Vector3 center;
	private Vector3 startPosRelCenter;
	private Vector3 endPosRelCenter;
	public bool canBounce;
	public bool canSlerp;
	private Vector3 dir;
	void Start(){
		center = (transform.position + bombStats.targetPoint) * 0.5F;
		center -= new Vector3 (0, 1, 0);
		startPosRelCenter = transform.position - center;
		endPosRelCenter = bombStats.targetPoint - center;
		startTime = Time.time;
		canBounce = true;
		canSlerp = true;
		Vector3 dir = transform.forward;
	}

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(rb.velocity.magnitude.ToString("F1"));
		Debug.Log (collisionCounter.ToString ("F1"));
		Destroy (this.gameObject, 4);
		//Press skill button : raycast from camera to mouseposition (marker on ground).
		//Press mouse button : instanciate ball at player pos , slerp from player to target and on collision addForce, after bounces destroy(explosion AoE)
		if (collisionCounter < 1) {
			float fracComplete;
			fracComplete = (Time.time - startTime) / bombStats.bounceTime;
			transform.position = Vector3.Slerp (startPosRelCenter, endPosRelCenter, fracComplete);
			transform.position += center;

		} else {
			rb.useGravity = true;
			if (canBounce) {
				StartCoroutine (ForceApply ());
			}
		}
//		if(canBounce) {
//			Vector3 dir = Quaternion.AngleAxis (bombStats.bounceAngle, transform.forward) * transform.right;
//			rb.AddForce (dir * bombStats.ballForce * Time.deltaTime, ForceMode.Impulse);
//			canBounce = false;
//		}

		//on collision add the force till destroy
		if (collisionCounter > (bombStats.maxBounces )) {
			//Insert particle effect on collison and AoE here
			Destroy (this.gameObject);
		}

        //Debug.Log (collisionCounter.ToString ("F1"));
	}

	void OnCollisionEnter(Collision collision){
		collisionCounter++;
		if (collision.gameObject.tag != "Player") {
			
		}
		if (collision.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
		}
	}

	IEnumerator ForceApply(){
		canBounce = true;
		rb.AddForce ((transform.forward - transform.up)  * bombStats.ballForce * Time.deltaTime, ForceMode.Impulse);
		yield return new WaitForEndOfFrame();
		canBounce = false;


	}
}

