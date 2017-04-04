using UnityEngine;
using System.Collections;

public class MinionTarget : MonoBehaviour {


    public MinionTargetManager myMinionTargetMan;


	// Use this for initialization
	void Start ()
    {

        myMinionTargetMan.targets.Add(transform);

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
