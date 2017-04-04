using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy target.
/// </summary>
public class MinionTarget {
	/// <summary>
	/// The target.
	/// </summary>
	public Transform target;
	/// <summary>
	/// The priority (bigger value, bigger priority)
	/// </summary>
	public int priority;
}
