using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
     GameController game_controller;
    private GameObject chooseLevel;

    bool valid=true;

    void Start() {
        game_controller = GameObject.FindObjectOfType<GameController>();
        if (game_controller == null)
        {
            Debug.LogError("GameController is null! Nothing can work!");
            valid = false;
        }

        chooseLevel = GameObject.Find("Continue");
        if (chooseLevel== null) Debug.LogError("chooseLivel is null!");
        else if (game_controller.Level_Completed >= 1) // Chiedere a Ciccio
            chooseLevel.SetActive(true);
            else chooseLevel.SetActive(false);

    }


    public void gotolevel(int scene) {
        if (!valid) return;
        if (game_controller.Level_Completed >= scene)
            game_controller.change_level(scene);
    }

    public void beganNewGame() {
        Application.LoadLevel(1);
    }

    public void chooseLevelScene() {
       Application.LoadLevel("LevelList");
    }
}
