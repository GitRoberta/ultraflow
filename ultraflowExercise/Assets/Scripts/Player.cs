using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    private Vector3 _velocity = new Vector3(0, 0, 0);
    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }
    public bool go;
    public float initialSpeed;
    public Vector3 starting_position;
    private int amount = 5;
    private int starting_amount = 5;

    public Text amounText;

    public int Amount
    {
        get { return amount; }
        set
        {
            if (value >= 0)
            {
                amount = value;
                //amounText.text = value.ToString();
                changeSprite(value);
            }
        }
    }


    void Start()
    {
        starting_position = this.transform.position;
        initialSpeed = 0.0f;
        go = false;
        starting_amount = amount;

    }


    void OnCollisionEnter2D(Collision2D coll) { }


    void Update()
    {
        if (amount == 0)
            die();
        if (go)
            transform.Translate(_velocity * Time.deltaTime);
    }

    void die()
    {
        Debug.Log("So long!");
        GameObject.Destroy(this.gameObject);
    }

    /* Reset amount and position */
    public void reset()
    {
        this.amount = starting_amount;
        this.transform.position = starting_position;
    }

    void changeSprite(int amount)
    {

        SpriteRenderer sprRenderer = GetComponent<Player>().GetComponentInChildren<SpriteRenderer>();
        Sprite[] newSprite = Resources.LoadAll<Sprite>("numeri"); // carico la sprite
        if (newSprite == null | newSprite.Length == 0) { Debug.Log("Caricamento sprite fallito"); }
        sprRenderer.sprite = (Sprite)newSprite[amount];
    }

}
