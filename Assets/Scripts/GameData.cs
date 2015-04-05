using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    private AssignmentManager assignmentManager;

    // Use this for initialization
    void Start() {
        assignmentManager = AssignmentManager.GetInstance();
    }

    public AssignmentManager GetAssignmentManager() {
        return assignmentManager;
    }
}
