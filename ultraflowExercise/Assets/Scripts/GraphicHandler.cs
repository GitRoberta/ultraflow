using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphicHandler : MonoBehaviour {

   private GameObject win;
   private GameObject nextLevel;
   private GameObject mainMenu;


	// Use this for initialization
	void Start () {
       win =  GameObject.Find("Win");
        if (win != null)win.SetActive(false);
        else Debug.LogError("Errore, win don't found.");
       nextLevel = GameObject.Find("NextLevel");
        if (nextLevel != null) nextLevel.SetActive(false);
        else Debug.LogError("Errore, nextLevel don't found.");
        mainMenu =  GameObject.Find("Main Menu");
        if (mainMenu != null) mainMenu.SetActive(false);
        else Debug.LogError("Errore,  mainMenu don't found.");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setActiveButtonInUi()
    {
       win.SetActive(true);
       nextLevel.SetActive(true);
       mainMenu.SetActive(true);
    }

   public void nextLevelLoad(int level) {
        //Carica il nextLevel
        Application.LoadLevel(level);
    }

   public void mainMenuOpen() {
        // Carica il main menu
        Application.LoadLevel("MainMenu");
    }
}
