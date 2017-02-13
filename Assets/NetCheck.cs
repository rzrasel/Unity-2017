using UnityEngine;
using System.Collections;

public class NetCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			Debug.Log ("Error. Check internet connection!");
		} else {
			Debug.Log("Internet connected");
		}
	}
}