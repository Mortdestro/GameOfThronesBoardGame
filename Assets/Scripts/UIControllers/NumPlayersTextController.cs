using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumPlayersTextController : MonoBehaviour {

    public Text text;
    public GameData gameData;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        text.text = gameData.GetNumPlayers() + " Players";
    }
}
