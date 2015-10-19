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
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Menu))
        {
            if (Application.loadedLevel >= 1)
                Application.LoadLevel(0);
            else Application.Quit();
            return;
        }
    }

    /* Passing the int for the scene index */
    public void change_level(int scene) {
        Application.LoadLevel(scene);
    }
	
	
}
