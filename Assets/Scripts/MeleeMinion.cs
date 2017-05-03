using UnityEngine;
using System.Collections;

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
}
