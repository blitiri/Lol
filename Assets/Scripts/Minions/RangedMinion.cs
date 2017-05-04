using UnityEngine;
using System.Collections;

public class RangedMinion : Minion
{
    public Transform LifeBar;
    public GameObject lifeSlidePrefab;

    // Use this for initialization
    void Start ()
    {
        GameObject lifeSlide = Instantiate(lifeSlidePrefab, LifeBar.position, Quaternion.identity) as GameObject;
        lifeSlide.GetComponent<UISprite>().SetAnchor(LifeBar);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
