using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GraphicHandler : MonoBehaviour {

   private GameObject win;
   private GameObject nextLevel;


	// Use this for initialization
	void Start () {
        win =  GameObject.Find("Win");
        if (win != null)win.SetActive(false);
        else Debug.LogError("Errore, win don't found.");
       nextLevel = GameObject.Find("NextLevel");
        if (nextLevel != null) nextLevel.SetActive(false);
        else Debug.LogError("Errore, nextLevel don't found.");
      
    }


   
    public void setActiveButtonInUi()
    {
       win.SetActive(true);
       nextLevel.SetActive(true);
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
