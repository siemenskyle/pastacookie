using UnityEngine;
using System.Collections;

public class EndScreenStars : MonoBehaviour {

    private float xPos;
    public int id;

	// Use this for initialization
	void Start () {
        xPos = gameObject.GetComponent<Transform>().position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (xPos <= -20)
        {
            xPos = 20;
        }

        if (id == 1)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(xPos, 0f, 0f);
            xPos = xPos - 0.04f;
        }
        else
        {
            gameObject.GetComponent<Transform>().position = new Vector3(xPos, 0f, 10f);
            xPos = xPos - 0.03f;
        }
	}
}
