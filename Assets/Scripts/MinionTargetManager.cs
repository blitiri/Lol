using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Enemy target.
/// </summary>
public class MinionTargetManager : MonoBehaviour
{
	/// <summary>
	/// The priority (bigger value, bigger priority)
	/// </summary>
	public int priority;

    public LayerMask target;

    Transform myTarget;
    Transform mySpawn;

    public List<Transform> targets = new List<Transform>();
    List<Transform> reachedTargets = new List<Transform>();
    List<Transform> spawns = new List<Transform>();

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        SelectStartTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SelectStartTarget()
    {
        float spawnTargetDistance = Vector3.Distance(mySpawn.position, myTarget.position);
        float spawnElementDistance;
        myTarget = targets[0];
        foreach (Transform element in targets)
        {
            spawnElementDistance = Vector3.Distance(mySpawn.position, element.position);
            if (spawnElementDistance < spawnTargetDistance)
            {
                myTarget = element;
                spawnTargetDistance = Vector3.Distance(mySpawn.position, element.position);
            }
        }
    }

    //void AddTarget()
    //{
    //    targets.Add()
    //}

    //IEnumerator ChangeTarget()
    //{

    //}
}
