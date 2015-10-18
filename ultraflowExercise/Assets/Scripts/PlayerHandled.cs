using UnityEngine;
using System.Collections;

public class PlayerHandled : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 direction;
    private bool directionChosen;
    private float velocity;

    // Use this for initialization
    void Start()
    {
        velocity = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 1)
        {
            var touch = Input.GetTouch(0);
            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    velocity = (touch.deltaPosition.magnitude / Time.deltaTime) * 0.007f;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;

                //Caso in cui tocca lo schermo ma non si muove, viene impressa una velocità minima e inizia comunque
                // il turno
                //case TouchPhase.Stationary:
                    //Debug.Log("Stationary");
                    //if (touch.position.Equals(startPos))
                    //{
                    //    direction = startPos;
                    //}
                    //else
                    //{
                    //    direction = touch.position - startPos;
                    //}
                    //directionChosen = true;
                    //break;
            }
        }else if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
        {
            doubleTap();
            reset();
        }

        if (directionChosen)
        {
            Player p = GetComponent<Player>() ?? null;
            if (p != null)
            {
                var distance = direction.magnitude; // 
                var dir = direction / distance; // non mettere queste 2 funzioni insieme non si capisce perchè sballa con codice in unica riga
                p.Velocity = new Vector3(dir.x, dir.y, 0)* velocity;
                p.go = true;
                p.initialSpeed = velocity;
                reset();
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cube")
        {
        }
    }

    void reset()
    {
        directionChosen = false;
        velocity = 0.01f;
        startPos = Vector2.zero;
        direction = Vector2.zero;
    }

    void doubleTap()
    {
        Player p = GetComponent<Player>() ?? null;
        if (p != null)
        {
            transform.position = p.starting_position;
            p.go = false;
            p.reset();
        }
    }
}
