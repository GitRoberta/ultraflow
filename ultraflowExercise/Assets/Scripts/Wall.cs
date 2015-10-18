using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D)),RequireComponent(typeof(SpriteRenderer)),RequireComponent(typeof(AudioSource))]
public class Wall : MonoBehaviour
{

    #region Variables
    
    private bool breakable = false;   /*  is breakable? */
    private bool exploded = false;  /* already exploded */
    private int num_hits = 0;   /* number of player hit  */
    private int sprite_index = 0; /* index of the array of sprite */
    private SpriteRenderer actual_sprite; /*actual sprite rendered, index 0 of our array */
    private Vector3 starting_position; /* starting position, used in reset method */

    [Range(0, 5)]
    public int break_counts = 0; /* maximim number of player hit allowed. <1 is unbreakable */
    public Sprite[] wall_sprites; /* Sprite array of the wall. When hitted, change his sprite */
    public AudioSource hit_sound; /*Sound when hitted */
    [Range(0,10)]
    public int num_fragments = 5; /* Number of fragment emitted at every hit with the player */

    #endregion


    #region StateMachineMethods

    void Start()
    {
        breakable = is_breakable();
        actual_sprite= GetComponent<SpriteRenderer>();
        hit_sound = GetComponent<AudioSource>();
        if (breakable)
        {
            if (break_counts > wall_sprites.Length)
            {
                Debug.LogError("Wall: not enought sprite to render if breakable");
                breakable = false;
            }
        }
        starting_position = this.transform.position;
    }

    

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!is_player(col)) return;
        hit();
        decrement_player_amount(col.gameObject);
        /* TODO:: testing with multiple contact points */
        ContactPoint2D contact_point = col.contacts[0];
        change_player_direction(col.gameObject,contact_point.normal);
    }

    #endregion

    #region UsefulMethods

    /* Detect if is player or not */
    bool is_player(Collision2D col) { return col.gameObject.tag == "Player"; }

    /*When player hit the wall, must increment the number of hits and eventually change sprite */
    void hit() {
        num_hits++;
        if(!hit_sound.isPlaying)
         hit_sound.Play();
        if (breakable)
        {
            if (num_hits > break_counts)
            {
                explode();
                make_fragments(5);
            }
            else
            { 
                change_sprite();
                make_fragments();
            }   
        }
        
    }

    /*Take the player script and change the number of amount */
    void decrement_player_amount(GameObject player) {
        Player p = player.GetComponent<Player>() ?? null;
        if(p!=null)
            p.Amount--;
    }

    /* Change player direction after the contact with the wall */
    void change_player_direction(GameObject player,Vector3 contact_normal) {
        Vector3 result_v = calculate_res_vector(player.transform.position,contact_normal);
         Player p = player.GetComponent<Player>() ?? null;
         if (p != null)
             p.Velocity = result_v;
    }

    /* Calculate the result vector between the normal  
       Following formula  v' = 2 * (v . n) * n - v
     */
    Vector3 calculate_res_vector(Vector3 velocity, Vector3 contact_normal) {
        Vector3 result = Vector3.zero;
        result = 2 * (Vector3.Dot(velocity, Vector3.Normalize(contact_normal))) * Vector3.Normalize(contact_normal) - velocity;  
        result *= -1;
        
        return result;
    }

    #endregion

    bool is_breakable() { return (break_counts > 0); }


     #region EffectMethods

    /* Create some fragment  */
    void make_fragments(int addictional_fragments=0) {
        for (int i = 0; i < (num_fragments + addictional_fragments); i++)
        { GameObject.Instantiate(Resources.Load("Fragment"), transform.position, transform.rotation); } 
    }

     /* Change sprite, depending number of the hit */
     void change_sprite() {
         this.actual_sprite.sprite = this.wall_sprites[sprite_index];
         sprite_index = (sprite_index == wall_sprites.Length) ? 0 : sprite_index++; 
     }

     /* Called by level handler, reset all the variables to start */
     public void reset() 
     {
         if (breakable)
         {
             num_hits = 0;
             change_sprite();
         }
         this.transform.position = starting_position;
     }

     /* 
        TODO :: When reach maximum amount of player bounces, explode with particle effect
     */
     public void explode()
     {
         exploded = true;
         this.gameObject.SetActive(false);
     }

     #endregion
    
}
