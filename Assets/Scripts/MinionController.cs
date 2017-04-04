using UnityEngine;
using System.Collections;


public class MinionController : MonoBehaviour
{


    bool isTarget;

    float sphereCastRadius;

    RaycastHit info;

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
    void Update()
    {

    }
}
