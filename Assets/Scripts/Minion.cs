using UnityEngine;
using System.Collections;


public class Minion : MonoBehaviour
{
    public float life;
    /// <summary>
    /// This minion's speed to get closer to its target.
    /// </summary>
    public float movementSpeedDuringAttack;
    /// <summary>
    /// The destination of this minion.
    /// </summary>
    public Vector3 myDestination;
    /// <summary>
    /// The target of minion's attack.
    /// </summary>
    public GameObject target;
    /// <summary>
    /// The NavMesh Agent of the single enemy minion.
    /// </summary>
    public NavMeshAgent myNavMeshAg;
    /// <summary>
    /// The minion to attack.
    /// </summary>
    public Minion otherMinion;

    private void Awake()
    {
        myNavMeshAg = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        AddgMyselfToTheIList();
        myDestination = myNavMeshAg.destination;
    }

    void AddgMyselfToTheIList()
    {
        MinionsManager.enemyMinions.Add(this);
    }

    public virtual IEnumerator Attack()
    {
        yield return null;
    }
}
