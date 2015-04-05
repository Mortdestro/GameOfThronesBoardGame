using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumPlayersTextController : MonoBehaviour {

    public Text text;
    public GameData gameData;
    private PlayerManager playerManager;

    void Start() {
        playerManager = gameData.GetPlayerManager();
    }

    // Update is called once per frame
    void Update() {
        text.text = playerManager.GetNumPlayers() + " Players";
    }
}
