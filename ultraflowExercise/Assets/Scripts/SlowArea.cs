﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D)), RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(AudioSource))]
public class SlowArea : EffectArea {
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
        {
            p.Velocity /= speed_factor;
            if (!speed_sound.isPlaying)
                speed_sound.Play();
        }
    }
	
}
