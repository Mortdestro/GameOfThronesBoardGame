using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    public int maxPlayers;

    private PlayerManager playerManager;
    private HouseManager houseManager;

	// Use this for initialization
	void Start () {
        playerManager = PlayerManager.GetInstance();
        playerManager.SetMaxPlayers(maxPlayers);
        Debug.Log("GameData start, " + maxPlayers);

        houseManager = HouseManager.GetInstance();
	}

    public PlayerManager GetPlayerManager() {
        return playerManager;
    }

    public HouseManager GetHouseManager() {
        return houseManager;
    }
}
