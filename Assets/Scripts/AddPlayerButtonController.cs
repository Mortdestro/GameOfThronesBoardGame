using UnityEngine;
using System.Collections;

public class AddPlayerButtonController : MonoBehaviour {

    public int maxPlayers;
    public GameData gameData;
    public PlayerManager playerManager;

    public void Start() {
        playerManager = gameData.GetPlayerManager();
        Debug.Log("Button start, " + playerManager.GetNumPlayers());
    }

    public void OnMouseUpAsButton() {
        playerManager.AddPlayer("Player " + playerManager.GetNumPlayers() + 1);
        Debug.Log("Player added");
    }
}
