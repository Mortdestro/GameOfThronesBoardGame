using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerListController : MonoBehaviour {

    public GameData gameData;
    public GameObject nameObject;
    public GameObject parentMenu;
    private int numPlayers;

    void Start() {
        numPlayers = gameData.GetNumPlayers();
    }

    void Update() {
        if (numPlayers != gameData.GetNumPlayers()) {
            foreach (GameObject name in GameObject.FindGameObjectsWithTag("PlayerName")) {
                Destroy(name);
            }
            Dictionary<string, Player> playerDict = gameData.GetPlayerDict();
            int i = 0;
            foreach (KeyValuePair<string, Player> currPair in playerDict) {
                Debug.Log(currPair.Key);
                nameObject.GetComponent<Text>().text = currPair.Key;
                GameObject thisName = (GameObject) Instantiate(nameObject);
                thisName.transform.SetParent(parentMenu.transform);
                thisName.transform.position = new Vector3(parentMenu.transform.position.x, parentMenu.transform.position.y + (100 - 50 * i), parentMenu.transform.position.z);
                i++;
            }
            numPlayers = gameData.GetNumPlayers();
        }
    }
}
