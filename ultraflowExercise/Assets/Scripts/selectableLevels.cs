using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class selectableLevels : MonoBehaviour {

    private Button[] level;
    GameController game_controller;
    int unlockedLevels;

    // Use this for initialization
    void Start () {
        level = GameObject.Find("levelList").GetComponents<Button>();
        if (game_controller == null)
            Debug.LogError("GameController is null! Nothing can work!");
        unlockedLevels = game_controller.Level_Completed;
        for (int i = 0; i <= unlockedLevels; i++) {
            level[i].interactable = true;
        }
        for (int i= unlockedLevels; i<level.Length; i++)
        {
            level[i].interactable = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
