using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    private Vector3 _velocity = new Vector3(0, 1, 0);
    public Vector3 Velocity { get { return _velocity; } set { _velocity = value; } }
    public bool go;
    public float initialSpeed;
    public Vector3 starting_position;
    private int amount = 5;
    private int starting_amount = 5;
    public bool isControllable;

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
        initialSpeed = 0.0f;
        go = false;
        starting_amount = amount;
        isControllable = true;
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
        isControllable = true;
    }

    /* Reset amount and position */
    public void reset()
    {
        Debug.Log("Reset Player");
        this.amount = starting_amount;
        changeSprite(amount);
        this.transform.position = starting_position;
        isControllable = true;
        go = false;
    }

    void changeSprite(int amount)
    {

        SpriteRenderer sprRenderer = GetComponent<Player>().GetComponentInChildren<SpriteRenderer>();
        Sprite[] newSprite = Resources.LoadAll<Sprite>("numeri"); 
        if (newSprite == null | newSprite.Length == 0) {
            Debug.LogError("Error Load."); }
        if (amount == 0)
            sprRenderer.sprite = (Sprite)newSprite[9];
        else {
            sprRenderer.sprite = (Sprite)newSprite[amount -1];
        }
    }

}
