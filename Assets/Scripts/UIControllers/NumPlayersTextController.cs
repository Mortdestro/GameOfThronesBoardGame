using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumPlayersTextController : MonoBehaviour {

    public PlayerData playerData;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (playerData.GetPlayer() != null)
            this.GetComponent<Text>().text = playerData.GetPlayer().name;
    }
}
