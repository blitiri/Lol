using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
