using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D)), RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(AudioSource))]
public class SlowArea : EffectArea {
    public AudioSource speed_sound;

    //public override void Start()
    //{
    //    speed_sound = GetComponent<AudioSource>();
    //}

    //public override void Update()
    //{

    //}

<<<<<<< HEAD
    //public override void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (!is_player(other)) return;
    //    Player p = other.GetComponent<Player>() ?? null;
    //    if (p != null)
    //    {
    //        p.Velocity /= speed_factor;
    //        if (!speed_sound.isPlaying)
    //            speed_sound.Play();
    //    }
    //}
=======
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!is_player(other)) return;
        Player p = other.GetComponent<Player>() ?? null;
        if (p != null)
        {
            float angle = Vector3.Angle(p.gameObject.transform.up, this.transform.up);
            p.transform.Rotate(-this.transform.forward, angle);
            p.Velocity /= speed_factor;
            if (!speed_sound.isPlaying)
                speed_sound.Play();
        }
    }
>>>>>>> d57fc2fbdb14cefec207096215807b05182a99a9
	
}
