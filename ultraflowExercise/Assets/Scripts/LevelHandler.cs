﻿using UnityEngine;
using System.Collections;

public class LevelHandler : MonoBehaviour
{
 
    public GameObject MovableObject;      /* Pass the empty that contains all the moving platform on the game, if null nothing happens */
    public GameObject DestroyableObjects; /* Pass the empty that contains all the destroyable objects on the game, if null nothing happens */
    public GameObject player;
    
    [Range(1,20)]
    public int start_amount = 5;
    private int level_completed = 0; /* Once we complete a level, this variable increases */
    [Range(1,4)]
    public int level_number; /* This is the level number */
    private bool completed = false; /* level completed */
    public bool Completed {
        get { return completed; }
        set { completed = value; }
    }

	void Start () {
        if (!is_valid())
        {
            Debug.LogError("LevelHandler: player or winmenu is null. I kill myself");
            GameObject.Destroy(this.gameObject);
        }
        
        Player p = player.GetComponent<Player>();
        p.Amount = start_amount;
       
    }
	
	
	void Update () {
	
	}

    /* Complete the level */
    public void complete() {
        if (!completed)
        {
            completed = true;
            GameObject gc = GameObject.Find("GameController");
            GameController game_controller = gc.GetComponent<GameController>() ?? null;
            game_controller.Level_Completed = level_number;
            GameObject gh = GameObject.Find("GraphicHandler");
            GraphicHandler graphicHandler = gh.GetComponent<GraphicHandler>() ?? null;
            graphicHandler.setActiveButtonInUi();
        }
    }

    /* Reset all elements of the level. */
   public void reset() 
    {
        if (DestroyableObjects != null)
        {
            Wall[] d_walls = DestroyableObjects.GetComponentsInChildren<Wall>(true);
            foreach (Wall w in d_walls)
            {
                if (!w.gameObject.activeSelf)
                    w.gameObject.SetActive(true);
                w.reset();
            }
        }
        Player p = FindObjectOfType<Player>();
        if(p!=null)
        p.reset();
    }

   bool is_valid() {
       return (player != null);
   }

}
