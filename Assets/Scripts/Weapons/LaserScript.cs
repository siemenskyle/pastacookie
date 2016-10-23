using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public int called;

	// Use this for initialization
	void Start () {
		called = 0;
	}

	// Update is called once per frame
	
	public void FireLaser(GameObject start, Vector3 target, LayerMask mask)
	{
		Vector3 targetnew = GetWorldPositionOnPlane((target ), 0f);
		Vector3 path = targetnew - start.transform.position;
		path = path.normalized;
		RaycastHit2D rayInfo = Physics2D.Raycast (start.transform.position, path, 50, mask);

		GameObject myLine = new GameObject();
		myLine.transform.position = start.transform.position;
		myLine.AddComponent<LineRenderer>();

		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material (Shader.Find ("Particles/Alpha Blended Premultiply"));
		lr.SetColors(Color.red, Color.red);
		lr.SetWidth(0.1f, 0.1f);
		lr.SetPosition(0, start.transform.position);


		if (!rayInfo.point.Equals(Vector2.zero)) {
			lr.SetPosition (1, rayInfo.point);
		} else {
			lr.SetPosition (1, targetnew);
		}
		GameObject.Destroy (myLine, 1f);
	}

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
}
