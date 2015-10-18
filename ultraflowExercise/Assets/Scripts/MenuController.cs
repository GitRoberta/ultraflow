using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
    
    GameController game_controller;
    bool valid=true;

    void Start() {
        if (game_controller == null)
        {
            Debug.LogError("GameController is null! Nothing can work!");
            valid = false;
        }
    
    }

    public void gotolevel(int scene) {
        if (!valid) return;
        if (game_controller.Level_Completed >= scene)
            game_controller.change_level(scene);
    }
}
