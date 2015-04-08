using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

    private Player player;

    void Start() {
        player = new Player ("Ned");
        DontDestroyOnLoad(this);
    }

    public Player GetPlayer() {
        return player;
    }

    public void SetPlayerName(string name) {
        this.player.name = name;
    }
}
