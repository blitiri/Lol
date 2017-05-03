using UnityEngine;
using System.Collections;

public class MeleeMinion : MonoBehaviour
{
    public GameObject lifeSlidePrefab;  

	// Use this for initialization
	void Start()
    {
       GameObject lifeSlide = Instantiate(lifeSlidePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
        lifeSlide.GetComponent<UISprite>().SetAnchor(transform);
    }
	
}
