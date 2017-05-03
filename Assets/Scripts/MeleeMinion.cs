using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class MeleeMinion : MonoBehaviour
{
    public GameObject lifeSlidePrefab;  

	// Use this for initialization
	void Start()
    {
       GameObject lifeSlide = Instantiate(lifeSlidePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
        lifeSlide.GetComponent<UISprite>().SetAnchor(transform);
    }
	
=======
public class MeleeMinion : Minion {

    /// <summary>
    /// The radius of the sphere that detects Enemies.
    /// </summary>
    public float sphereCastRadius;
    /// <summary>
    /// The hit point of the detect-enemy spherecast.
    /// </summary>
    public RaycastHit hit;
    /// <summary>
    /// The weapon of the minion.
    /// </summary>
    public GameObject sword;

    //void DetectEnemy()
    //{
    //    Physics.SphereCast(transform.position, sphereCastRadius, Vector3.zero, out hit, 0);
    //    if (gameObject.tag == Register.enemyMinionLayer) ;
    //}
>>>>>>> 33133c63ecb3a33fcadc8d18a742cbd41333f26b
}
