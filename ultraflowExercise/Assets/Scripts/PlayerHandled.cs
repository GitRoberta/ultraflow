using UnityEngine;
using System.Collections;

public class PlayerHandled : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 direction;
    private bool directionChosen;
    private float velocity;
    private Player p;
    private bool areaControl;

    public bool AreaControl
    {
        get { return areaControl; }
        set
        {
            areaControl = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        velocity = 0.01f;
        p = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 1 && p.isControllable)
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
                    if (!areaControl) {
                        p.isControllable = false;
                        directionChosen = true;
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    p.isControllable = false;
                    break;
            }
        }else if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
        {
            WinArea winarea = GameObject.Find("GravityArea").GetComponentInChildren<WinArea>();
            if(!winarea.completed)
            doubleTap();
        }

        if (directionChosen)
        {
            if (p != null)
            {
                var distance = direction.magnitude; 
                var dir = direction / distance; 
                p.Velocity = new Vector3(dir.x, dir.y, 0)* velocity;
                p.go = true;
                p.initialSpeed = velocity;
                reset();
            }
        }

    }

   public void reset()
    {
        directionChosen = false;
        velocity = 0.01f;
        startPos = Vector2.zero;
        direction = Vector2.zero;
        areaControl = true;
    }

    void doubleTap()
    {
        reset();
        LevelHandler levelHandler = FindObjectOfType<LevelHandler>();
        if (levelHandler != null) {
            levelHandler.reset();
        }
    }

    }
