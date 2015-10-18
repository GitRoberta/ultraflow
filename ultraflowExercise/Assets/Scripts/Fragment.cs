using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Fragment : MonoBehaviour {
    
    /* Velocity parameters */
    [Range(1,10)]
    public int start_speed = 3;
    private Vector3 direction;

    /* Life of the fragment */
    public int fragment_life = 3;
    public System.DateTime fragment_death;
	
	void Start () {
        direction = new Vector3(Random.value,Random.value,Random.value);
        fragment_death = System.DateTime.Now.AddSeconds(fragment_life);
	}
	
	void Update () {
        if (System.DateTime.Now > fragment_death)
        {
            Debug.Log("Fragment: bye bye!");
            GameObject.Destroy(this.gameObject);
        }

        transform.Translate(direction* Time.deltaTime* start_speed);
	}
}
