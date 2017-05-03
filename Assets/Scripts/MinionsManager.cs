using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manage enemies spawing.
/// </summary>
public class MinionsManager : MonoBehaviour {
	/// <summary>
	/// The melee attack minion prefab.
	/// </summary>
	public GameObject meleeMinionPrefab;
	/// <summary>
	/// The range attack minion prefab.
	/// </summary>
	public GameObject rangedMinionPrefab;
    /// <summary>
    /// It is needed not to start more than 1 SpawnEnemyMinionsIsRunning().
    /// </summary>
    private bool SpawnEnemyMinionsIsRunning;
	/// <summary>
	/// The melee attack minions quantity per horde.
	/// </summary>
	public float meleeQuantity = 3;
	/// <summary>
	/// The melee attack minions quantity increase after a certain time
	/// </summary>
	public float meleeIncrease = 2;
	/// <summary>
	/// The melee attack minions quantity increase timeout.
	/// </summary>
	public float meleeIncreaseTimeout = 10;
	/// <summary>
	/// The range attack minions quantity per horde.
	/// </summary>
	public float rangedQuantity = 1;
	/// <summary>
	/// The range attack minions quantity increase after a certain time
	/// </summary>
	public float rangedIncrease = 1;
	/// <summary>
	/// The range attack minions quantity increase timeout.
	/// </summary>
	public float rangedIncreaseTimeout = 15;
    /// <summary>
    /// The priority (bigger value, bigger priority)
    /// </summary>
    public int priority;
    /// <summary>
    /// The total number of enemy minions.
    /// </summary>
    public int enemyMinions;
    /// <summary>
    /// The time between a minion spawn and the following.
    /// </summary>
    public float timeToSpawn;
    /// <summary>
    /// Time between a minion horde spawn and the following one.
    /// </summary>
    private float timer;
    /// <summary>
    /// all NavMesh Area Masks in binary code.
    /// </summary>
    public int[] NavAreaMasks = { 9, 17, 33 };
    /// <summary>
    /// All enemy minion spawners.
    /// </summary>
    public Transform[] spawners;
    /// <summary>
    /// Minions destinations.
    /// </summary>
    public Transform[] destinations;
    /// <summary>
    /// The array including all minion types.
    /// </summary>
    private GameObject[] minionPrefabs;
    /// <summary>
    /// All enemy MinionController.
    /// </summary>
    public static IList<Minion> minions = new List<Minion>();

    private void Start()
    {
        minionPrefabs = new GameObject[] { meleeMinionPrefab, rangedMinionPrefab };
        timer = 15;
    }

    private void Update()
    {
        if (timer < 15)
        {
            timer += Time.deltaTime;
        }
        else if (timer >= 15 && !SpawnEnemyMinionsIsRunning)
        {
            StartCoroutine(SpawnEnemyMinions());
            SpawnEnemyMinionsIsRunning = true;
        }
    }

    /// <summary>
    /// It spawns enemy minions on request.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemyMinions()
    {
        Vector3 position;
        for (int i = 0; i < enemyMinions; i++)
        {
            Debug.Log(i);
            int index = Random.Range(0, spawners.Length);
            int minionIndex = (i % 2) == 0 ? 0 : 1;
            GameObject enemyMinion = Instantiate(minionPrefabs[minionIndex], spawners[index].position, minionPrefabs[minionIndex].transform.rotation) as GameObject;
            enemyMinion.layer = Register.enemyMinionLayer;
            //enemyMinion.tag = spawnIndex.ToString();
            NavMeshAgent enemyMinionAgent = enemyMinion.GetComponent<NavMeshAgent>();
            enemyMinionAgent.areaMask = NavAreaMasks[index];
            enemyMinion.tag = Register.laneTags[index];
            enemyMinionAgent.SetDestination(destinations[0].position);
            //foreach (Transform item in destinations)
            //{
            //    if (item.tag == tag)
            //        enemyMinionAgent.SetDestination(item.position);
            //}
            yield return new WaitForSeconds(timeToSpawn);
        }
        timer = 0.0f;
        SpawnEnemyMinionsIsRunning = false;
    }
}


//new Vector3(spawners[spawnIndex].position.x + minionPrefabs[minionIndex].transform.lossyScale.x* i, spawners[spawnIndex].position.y, spawners[spawnIndex].position.z)