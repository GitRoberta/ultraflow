using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour {

    public enum FollowType { 
        MoveTowards,
        Lerp
    }

    public FollowType follow_type=FollowType.MoveTowards;
    public Path path;

    [Range(0f,20f)]
    public float speed = 1f;
    
    public float max_distance_to_go = 0.2f;

    private IEnumerator<Transform> _current_point;

    public void Start() {
        if (path == null)
        {
            Debug.LogError("Path cannot be null", gameObject);
            return;
        }
        _current_point = path.get_path_enumerator(); /* yeald break */
        _current_point.MoveNext();  /* next cycle of the loop of get_path_enumerator */

        if (_current_point.Current == null) return;

        this.transform.position = _current_point.Current.position;
    }


    public void Update() {
        if (_current_point == null || _current_point.Current == null) return;

        if (follow_type == FollowType.MoveTowards)
            this.transform.position = Vector3.MoveTowards(transform.position,_current_point.Current.position,Time.deltaTime*speed);

        if (follow_type == FollowType.Lerp)
            this.transform.position = Vector3.Lerp(transform.position, _current_point.Current.position, Time.deltaTime * speed);

        float distance = (this.transform.position - _current_point.Current.position).sqrMagnitude;
        if (distance < (max_distance_to_go * max_distance_to_go))
         _current_point.MoveNext();
        

    }
}
