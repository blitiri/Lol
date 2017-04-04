using UnityEngine;
using System.Collections;

public class MinionController : MonoBehaviour {


    bool isTarget;

    float sphereCastRadius;

    RaycastHit info;

    public LayerMask target;

    public Transform target1;
    public Transform target2;
    public Transform targetPlayer;

    public NavMeshAgent myNavMeshAg;

    void Awake()
    {
        myNavMeshAg = GetComponent<NavMeshAgent>();
    }

    // Use this for initialization
    void Start () {
        sphereCastRadius = transform.lossyScale.x / 2;
	}
	
	// Update is called once per frame
	void Update () {
        TargetChecking();
        TargetManaging();
        isTarget = TargetChecking();
	}

    void TargetManaging()
    {
        if (myNavMeshAg.destination == null)
        {
            myNavMeshAg.SetDestination(target1.position);
        }
        if (isTarget)
        {

        }
    }

    bool TargetChecking()
    {
        bool isTarget;

        if (Physics.SphereCast(transform.position, sphereCastRadius, transform.forward, out info, 0, target))
        {
            isTarget = true;
        }
        else
        {
            isTarget = false;
        }
        return isTarget;
    }
}
