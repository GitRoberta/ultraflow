using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class selectableLevels : MonoBehaviour {

    private Button[] level;
    private GameController game_controller;
    int unlockedLevels;

    // Use this for initialization
    void Start () {
        game_controller = GameObject.Find("GameController").GetComponent<GameController>();
        level = GameObject.Find("LevelList").GetComponentsInChildren<Button>();
        if (game_controller == null)
            Debug.LogError("GameController is null! Nothing can work!");
        unlockedLevels = game_controller.Level_Completed;
        for (int i = 0; i < level.Length; i++) {
            level[i].interactable = (i <= unlockedLevels) ;
            level[i].gameObject.SetActive((i <= unlockedLevels));
        }

    }


   public  void select_level(int i=1) { 
     if(game_controller==null)
         game_controller = GameObject.Find("GameController").GetComponent<GameController>();
     game_controller.change_level(i);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
