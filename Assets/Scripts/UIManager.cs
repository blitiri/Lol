using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public static UIManager instance; 
	public UIButton qButton;
	public UIButton wButton;
	public UIButton eButton;
	public UIButton rButton;

	void Awake(){
		instance = this;
	}
}
