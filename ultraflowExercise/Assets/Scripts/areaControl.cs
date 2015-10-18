using UnityEngine;
using System.Collections;

public class areaControl : EffectArea {

  
   public override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            PlayerHandled p = other.GetComponent<PlayerHandled>();
            p.AreaControl = true;
        }
    }


    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHandled p = other.GetComponent<PlayerHandled>();
            p.AreaControl = false;
        }
    }
}
