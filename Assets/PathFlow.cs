using UnityEngine;
using System.Collections;

public class PathFlow : MonoBehaviour {
	public PathFind pathFind;
	public int currentWayPoinId = 0;
	public float speed = 2f;
	private float reachDistance = 1.0f;
	public float rotationSpeed = 5.0f;
	public string pathName;
	public GameObject[] allPaths;

	Vector3 lastPosition;
	Vector3 currentPosition;
	// Use this for initialization
	void Start () {
		pathFind = GameObject.Find (pathName).GetComponent<PathFind>();
		lastPosition = transform.position;
		//Debug.Log (name);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentWayPoinId >= pathFind.pathObjs.Count) {
			//currentWayPoinId = 0;
			//GetPath getPath = new GetPath();
			GetPath getPath = gameObject.GetComponent<GetPath>();
			getPath.resetPathName ();
			pathFind = GameObject.Find (pathName).GetComponent<PathFind>();
			//lastPosition = transform.position;
			currentWayPoinId = 0;
		}
		float distance = Vector3.Distance (pathFind.pathObjs[currentWayPoinId].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, pathFind.pathObjs[currentWayPoinId].position, Time.deltaTime * speed);

		/*Vector3 object_pos = Camera.main.WorldToScreenPoint(pathFind.pathObjs[currentWayPoinId].position);

		float smooth = 2.0f;
		Vector3 gamePos = new Vector3(0f, 0f, 0f);
		float angle;
		gamePos.z = 5.23f;
		gamePos.x = gamePos.x - object_pos.x;
		gamePos.y = gamePos.y - object_pos.y;
		angle = Mathf.Atan2(gamePos.y, gamePos.x) * Mathf.Rad2Deg - 90;
		//transform.rotation = Quaternion.Euler(Vector3(0f, 0f, angle));
		Quaternion target = Quaternion.Euler(gamePos.x, gamePos.y, angle);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/

		Vector3 go = pathFind.pathObjs[currentWayPoinId].position;

		Vector3 dir = transform.position - go;
		dir.Normalize ();
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler (0, 0, zAngle);

		if (distance <= reachDistance) {
			currentWayPoinId++;
		}
	}
}