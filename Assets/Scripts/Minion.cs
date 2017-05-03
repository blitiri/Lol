using UnityEngine;
using System.Collections;


public class Minion : MonoBehaviour
{

    /// <summary>
    /// The NavMesh Agent of the single enemy minion.
    /// </summary>
    NavMeshAgent myNavMeshAg;

    private void Awake()
    {
        myNavMeshAg = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        AddgMyselfToTheIList();
    }

    void AddgMyselfToTheIList()
    {
        MinionsManager.enemyMinions.Add(this);
    }
}
