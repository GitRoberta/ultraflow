using UnityEngine;
using System.Collections;

public class WinArea : EffectArea {

   public bool completed = false;
    
    public override void OnTriggerStay2D(Collider2D other)
    {
        if (is_player(other) && !completed)
        {
            LevelHandler lh = GameObject.Find("LevelHandler").GetComponent<LevelHandler>();
            lh.complete();
            completed = true;
        }
    }
}
