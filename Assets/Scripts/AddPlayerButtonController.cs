using UnityEngine;
using System.Collections;

public class AddPlayerButtonController : MonoBehaviour {

    public int maxPlayers;
    public GameData gameData;
    public AssignmentManager assignmentManager;

    public void Start() {
        assignmentManager = gameData.GetAssignmentManager();
    }

    public void OnClick() {
        Player newPlayer = assignmentManager.AddPlayer("Player " + (assignmentManager.GetNumPlayers() + 1));
        if (newPlayer != null) {
            assignmentManager.AssignHouse(newPlayer, AssignmentManager.RANDOM);
            Debug.Log(newPlayer.name + ": House " + newPlayer.house.name);
        }
        else {
            Debug.Log("Max players reached.");
        }
    }
}
