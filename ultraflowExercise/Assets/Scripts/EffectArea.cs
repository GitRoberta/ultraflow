using UnityEngine;
using System.Collections;

public class EffectArea : MonoBehaviour {

    public bool always=false;
    [Range(1,10)]
    public int speed_factor = 1;

    #region VirtualMethods

    public virtual void Start () {
	
	}
	
	public virtual void Update () {
	
	}

    public virtual void OnTriggerEnter2D(Collider2D other) { }
    public virtual void OnTriggerStay2D(Collider2D other) { }
    public virtual void OnTriggerExit2D(Collider2D other) { }
    
    #endregion

    public bool is_player(Collider2D other) { return other.gameObject.tag == "Player"; }
}
