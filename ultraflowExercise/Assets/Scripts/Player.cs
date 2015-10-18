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
    private int amount = 13;
    private int starting_amount = 13;
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

        SpriteRenderer[] spr = GameObject.Find("Player").GetComponentsInChildren<SpriteRenderer>();
        if(amount <= 9) {
            Sprite newSprite = Resources.Load<Sprite>(amount.ToString());
            if (newSprite == null)
                Debug.LogError("Error Load.");
                spr[1].sprite = (Sprite) newSprite ;
            spr[2] = spr[3] = null;
        }

        if (amount > 9) {
            int unita, decina;
            decina=(int) amount / 10;
            unita = amount - decina * 10;
            Debug.Log("Decina is" + decina + "Unita is" + unita);
            Sprite spriteDecina = Resources.Load<Sprite>(decina.ToString());
            Sprite spriteUnita = Resources.Load<Sprite>(unita.ToString());
            spr[2].sprite = spriteDecina;
            spr[3].sprite = spriteUnita;
            spr[1] = null;
        }
    }

}
