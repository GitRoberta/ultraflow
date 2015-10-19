using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    private Vector3 _velocity = new Vector3(0, 1, 0);
    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }
    public bool go;
    public float speed;
    public Vector3 starting_position;
    private int amount = 13;
    private int starting_amount = 13;
    public bool isControllable;
    /* Number of fragment emitted after the death*/
    public int fragment_number = 5;
    /* Sprite that represents the single amount (amount <10) */
    public GameObject single_amount_sprite;
    /* Sprite that represents the half-score of the amount (amount >=10)*/
    public GameObject half_score_amount;
    /* Sprite that represents the unity of the amount */
    public GameObject unity_score_amount;
    /* this is the trail render of the player */
    private TrailRenderer trail_renderer;

    public Text amounText;

    public int Amount
    {
        get { return amount; }
        set
        {
            if (value >= 0)
            {
                amount = value;
                changeSprite(value);
            }
        }
    }

    void Start()
    {
        starting_position = this.transform.position;
        speed = 0.0f;
        go = false;
        starting_amount = amount;
        isControllable = true;
        trail_renderer = GetComponent<TrailRenderer>();
        trail_renderer.sortingLayerName = "Objects";
        trail_renderer.sortingOrder = 2;
    }


    void OnCollisionEnter2D(Collision2D coll) { }


    void Update()
    {
        if (amount == 0)
            die();
        if (go)
            transform.Translate(_velocity * Time.deltaTime);
    }

    void die(){
        Debug.Log("So long!");
        go = false;
        SpriteRenderer sprite_render = this.gameObject.GetComponent<SpriteRenderer>() ?? null;
        if (sprite_render != null)
            sprite_render.enabled = false;
        isControllable = true;
        make_fragments();
    }

    /* Reset amount and position */
    public void reset()
    {
        Debug.Log("Reset Player");
        this.amount = starting_amount;
        changeSprite(amount);
        this.transform.position = starting_position;
        SpriteRenderer sprite_render = this.gameObject.GetComponent<SpriteRenderer>() ?? null;
        if (sprite_render != null)
            sprite_render.enabled = true;
        isControllable = true;
        go = false;
    }

    #region EffectMethods

    void make_fragments() {
        for (int i = 0; i < fragment_number; i++)
        {
            Instantiate(Resources.Load("FragmentPlayer"),this.transform.position,this.transform.rotation);
        }
    }

    /* Change the displayed amount of the player */
    void changeSprite(int amount)
    {
        SpriteRenderer sprite_render=null;
        if(amount <= 9) 
        {    
            sprite_render=single_amount_sprite.GetComponent<SpriteRenderer>();
            Sprite newSprite = Resources.Load<Sprite>(amount.ToString());
            if (newSprite == null)
                Debug.LogError("Error on loading the sprite.");
            else
                sprite_render.sprite = newSprite;
        }

        if (amount > 9) 
        {
            int unita, decina;
            decina=(int) amount / 10;
            unita = amount - decina * 10;
            Sprite spriteDecina = Resources.Load<Sprite>(decina.ToString());
            Sprite spriteUnita = Resources.Load<Sprite>(unita.ToString());
            SpriteRenderer sprite_renderer= half_score_amount.GetComponent<SpriteRenderer>();
            SpriteRenderer sprite_renderer_unity = unity_score_amount.GetComponent<SpriteRenderer>();
            sprite_render.sprite = spriteDecina;
            sprite_renderer_unity.sprite = spriteUnita;
        }
    }
    #endregion

}
