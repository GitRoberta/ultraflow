using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1) {
            float x = 0, y=0;
            if (Input.touches[0].deltaPosition.x > -3 && Input.touches[0].deltaPosition.x < 3) {
                x = Input.touches[0].deltaPosition.x;
            }
            if (Input.touches[0].deltaPosition.y > -3 && Input.touches[0].deltaPosition.y < 5)
            {
                y = Input.touches[0].deltaPosition.y;
            }
            transform.Translate(x,y, 0);
        }
	}
}
