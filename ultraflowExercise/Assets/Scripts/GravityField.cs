using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D)), RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(AudioSource))]
public class GravityField : EffectArea {

    public AudioSource speed_sound;

    public override void Start()
    {
        speed_sound = GetComponent<AudioSource>();
    }

    public override void Update()
    {

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!is_player(other)) return;
        Player p = other.GetComponent<Player>() ?? null;
        if (p != null)
            come_here(p); 
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (!is_player(other)) return;
        Player p = other.GetComponent<Player>() ?? null;
        if (p != null)
            come_here(p); 
    }

    void come_here(Player p) {
        Vector3 gravity_direction = this.gameObject.transform.position - p.gameObject.transform.position;
        p.Velocity = gravity_direction;
        if (!speed_sound.isPlaying)
            speed_sound.Play();
    }

}
