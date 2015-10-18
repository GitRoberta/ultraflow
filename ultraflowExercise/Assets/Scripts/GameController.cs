using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private int level_completed = 0; /* Once we complete a level, this variable increases */
    public int Level_Completed {
        get { return level_completed; }
        set { if (value > level_completed) level_completed = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    /* Passing the int for the scene index */
    void change_level(int scene) {
        Application.LoadLevel(scene);
    }
	
	
}
