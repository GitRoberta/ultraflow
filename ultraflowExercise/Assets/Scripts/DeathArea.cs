using UnityEngine;
using System.Collections;

public class DeathArea : EffectArea{

    bool dead = false;

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (is_player(other) && !dead)
        {
            Player p = other.gameObject.GetComponent<Player>();
            p.Amount = 0;
            dead = true;
        }
    }
}
