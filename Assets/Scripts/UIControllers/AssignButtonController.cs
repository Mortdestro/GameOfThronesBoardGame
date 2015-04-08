using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AssignButtonController : MonoBehaviour {

    public GameData gameData;

    public void OnClick() {
        Dictionary<string, Player> playerDict = gameData.GetPlayerDict();
        try {
            gameData.InitializeHouses();
            foreach (KeyValuePair<string, Player> currPair in playerDict) {
                gameData.AssignHouse(currPair.Value, gameData.RandomHouse());
                Debug.Log(currPair.Value.name + ": House " + currPair.Value.house.name);
            }
        }
        catch (ApplicationException e) {
            Debug.LogError(e.Message);
        }
    }
}
