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
    /// All enemy minion spawners.
    /// </summary>
    public Transform[] spawners;
    /// <summary>
    /// The array including all minion types.
    /// </summary>
    public GameObject[] minionPrefabs;
    /// <summary>
    /// All enemy MinionController.
    /// </summary>
    public static IList<MinionController> minionControllers = new List<MinionController>();

    private void Start()
    {
        minionPrefabs = new GameObject[] { meleeMinionPrefab, rangedMinionPrefab };
        StartCoroutine(SpawningEnemyMinions());
    }

    /// <summary>
    /// It spawns enemy minions on request.
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawningEnemyMinions()
    {
        Vector3 position;
        for (int i = 0; i < enemyMinions; i++)
        {
            int spawnIndex = Random.Range(0, spawners.Length);
            int minionIndex = (i % 2) == 0 ? 0 : 1;
            GameObject enemyMinion = Instantiate(minionPrefabs[minionIndex], new Vector3(spawners[spawnIndex].position.x + minionPrefabs[minionIndex].transform.lossyScale.x * i, spawners[spawnIndex].position.y, spawners[spawnIndex].position.z), minionPrefabs[minionIndex].transform.rotation) as GameObject;
            enemyMinion.layer = Register.enemyMinionLayer;
            enemyMinion.tag = spawnIndex.ToString();
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
