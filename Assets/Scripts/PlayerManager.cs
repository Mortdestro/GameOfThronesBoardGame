using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager {

    private static PlayerManager playerManager;
    private List<Player> list;
    private int maxPlayers;

    private PlayerManager() {
        this.list = new List<Player>();
        this.maxPlayers = 0;
    }

    public static PlayerManager GetInstance() {
        if (playerManager == null)
            playerManager = new PlayerManager();
        return playerManager;
    }

    public bool AddPlayer(string name) {
        if (list.Count + 1 > maxPlayers)
            return false;
        list.Add(new Player(name));
        return true;
    }

    public int GetNumPlayers() {
        return list.Count;
    }

    public int GetMaxPlayers() {
        return maxPlayers;
    }

    public void SetMaxPlayers(int maxPlayers) {
        this.maxPlayers = maxPlayers;
    }

    public void AssignHouse(Player player, int house) {
        bool taken = false;
        foreach (Player currPlayer in list) {
            if (currPlayer.GetHouse() == HouseManager.GetInstance().Get(house)) {
                taken = true;
                break;
            }
        }
        if (!taken)
            player.SetHouse(HouseManager.GetInstance().Get(house));
    }

}
