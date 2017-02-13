using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour {
	public GameObject[] allPaths;
	// Use this for initialization
	void Start () {
		resetPathName ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void resetPathName()
	{
		int num = Random.Range (0, allPaths.Length);
		transform.position = allPaths [num].transform.position;
		PathFlow pathFlow = GetComponent<PathFlow> ();
		pathFlow.pathName = allPaths [num].name;
	}
}