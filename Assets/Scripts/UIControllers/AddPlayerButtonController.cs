using UnityEngine;
using System.Collections;

public class AddPlayerButtonController : MonoBehaviour {

    public GameData gameData;

    public void OnClick() {
        if (gameData.GetNumPlayers() + 1 <= gameData.maxPlayers) {
            Player newPlayer = gameData.AddPlayer("Player " + (gameData.GetNumPlayers() + 1));
            Debug.Log(newPlayer.name);
        }
        else {
            Debug.Log("Max players reached.");
        }
    }
}
