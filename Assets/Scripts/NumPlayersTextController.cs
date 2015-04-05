using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumPlayersTextController : MonoBehaviour {

    public Text text;
    public GameData gameData;
    private AssignmentManager assignmentManager;

    void Start() {
        assignmentManager = gameData.GetAssignmentManager();
    }

    // Update is called once per frame
    void Update() {
        text.text = assignmentManager.GetNumPlayers() + " Players";
    }
}
