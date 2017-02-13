using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFind : MonoBehaviour {
	public Color rayColor = Color.white;
	public List<Transform> pathObjs = new List<Transform> ();
	Transform[] theArray;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnDrawGizmos()
	{
		Gizmos.color = rayColor;
		theArray = GetComponentsInChildren<Transform> ();
		pathObjs.Clear();
		foreach(Transform pathObj in theArray)
		{
			if (pathObj != this.transform) {
				pathObjs.Add (pathObj);
			}
		}
		for (int i = 0; i < pathObjs.Count; i++) {
			Vector3 position = pathObjs [i].position;
			if (i > 0) {
				Vector3 previous = pathObjs [i - 1].position;
				Gizmos.DrawLine (previous, position);
				Gizmos.DrawWireSphere (position, 0.3f);
			}
		}
	}
}