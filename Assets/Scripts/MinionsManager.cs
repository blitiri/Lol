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
    private bool SpawnMinionsIsRunning;
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
    /// The number of enemy minions spwned each time.
    /// </summary>
    public int enemyMinionsCount;
    /// <summary>
    /// The number of allied minions spawned each time.
    /// </summary>
    public int alliedMinionsCount;
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
    public Transform[] enemySpawners;
    /// <summary>
    /// All allied minions spawners.
    /// </summary>
    public Transform[] alliedSpawners;
    /// <summary>
    /// Enemy minions destinations.
    /// </summary>
    public Transform[] enemyDestinations;
    /// <summary>
    /// Allied minions destinations.
    /// </summary>
    public Transform[] alliedDestinations;
    /// <summary>
    /// The array including all minion types.
    /// </summary>
    private GameObject[] minionPrefabs;
    /// <summary>
    /// All enemy MinionController.
    /// </summary>
    public static IList<Minion> enemyMinions = new List<Minion>();

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
        else if (timer >= 15 && !SpawnMinionsIsRunning)
        {
            StartCoroutine(SpawnEnemyMinions());
            StartCoroutine(SpawnAlliedMinions());
            SpawnMinionsIsRunning = true;
        }
    }

    /// <summary>
    /// It spawns enemy minions.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEnemyMinions()
    {
        Vector3 position;
        for (int i = 0; i < enemyMinionsCount; i++)
        {
            //Debug.Log(i);
            int index = Random.Range(0, enemySpawners.Length);
            int minionIndex = (i % 2) == 0 ? 0 : 1;
            GameObject enemyMinion = Instantiate(minionPrefabs[minionIndex], enemySpawners[index].position, minionPrefabs[minionIndex].transform.rotation) as GameObject;
            //enemyMinion.layer = Register.enemyMinionLayer;
            //enemyMinion.tag = spawnIndex.ToString();
            NavMeshAgent enemyMinionAgent = enemyMinion.GetComponent<NavMeshAgent>();
            enemyMinionAgent.areaMask = NavAreaMasks[index];
            enemyMinion.tag = Register.enemyMinionTag;
            enemyMinion.layer = Register.laneLayers[index];
            enemyMinionAgent.SetDestination(enemyDestinations[0].position);
            //foreach (Transform item in destinations)
            //{
            //    if (item.tag == tag)
            //        enemyMinionAgent.SetDestination(item.position);
            //}
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    /// <summary>
    /// It spawns allied minions.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnAlliedMinions()
    {
        Vector3 position;
        for (int i = 0; i < alliedMinionsCount; i++)
        {
            //Debug.Log(i);
            int index = Random.Range(0, alliedSpawners.Length);
            int minionIndex = (i % 2) == 0 ? 0 : 1;
            GameObject alliedMinion = Instantiate(minionPrefabs[minionIndex], alliedSpawners[index].position, minionPrefabs[minionIndex].transform.rotation) as GameObject;
            //alliedMinion.layer = Register.alliedMinionLayer;
            //enemyMinion.tag = spawnIndex.ToString();
            alliedMinion.GetComponent<MeshRenderer>().material.color = Color.yellow;
            NavMeshAgent alliedMinionAgent = alliedMinion.GetComponent<NavMeshAgent>();
            alliedMinionAgent.areaMask = NavAreaMasks[index];
            alliedMinion.tag = Register.alliedMinionTag;
            alliedMinion.layer = Register.laneLayers[index];
            alliedMinionAgent.SetDestination(alliedDestinations[0].position);
            //foreach (Transform item in destinations)
            //{
            //    if (item.tag == tag)
            //        enemyMinionAgent.SetDestination(item.position);
            //}
            yield return new WaitForSeconds(timeToSpawn);
        }
        timer = 0.0f;
        SpawnMinionsIsRunning = false;
    }
}


//new Vector3(spawners[spawnIndex].position.x + minionPrefabs[minionIndex].transform.lossyScale.x* i, spawners[spawnIndex].position.y, spawners[spawnIndex].position.z)