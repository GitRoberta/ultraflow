using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Fragment : MonoBehaviour {
    
    /* Velocity parameters */
    [Range(1,10)]
    public int start_speed = 3;
    private Vector3 direction;

    public int fragment_life = 3;

	
	void Start () {
        direction = new Vector3(Random.value,Random.value,Random.value);
	}
	
	void Update () {
        transform.Translate(direction* Time.deltaTime* start_speed);
	}
}
