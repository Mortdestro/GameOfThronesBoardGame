using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AssignmentManager {

    public const int BARATHEON = 0;
    public const int LANNISTER = 1;
    public const int STARK = 2;
    public const int GREYJOY = 3;
    public const int TYRELL = 4;
    public const int MARTELL = 5;
    public const int RANDOM = 6;

    private static AssignmentManager assignmentManager;

    private Dictionary<string, Player> playerDict;
    private List<House> houseList;

    private AssignmentManager() {
        this.playerDict = new Dictionary<string, Player>();
        this.houseList = new List<House>();
        houseList.Add(new House("Baratheon"));
        houseList.Add(new House("Lannister"));
        houseList.Add(new House("Stark"));
        houseList.Add(new House("Greyjoy"));
        houseList.Add(new House("Tyrell"));
        houseList.Add(new House("Martell"));
    }

    public static AssignmentManager GetInstance() {
        if (assignmentManager == null)
            assignmentManager = new AssignmentManager();
        return assignmentManager;
    }

    public int GetNumPlayers() {
        return playerDict.Count;
    }

    public int GetMaxPlayers() {
        return houseList.Count;
    }

    public House GetHouse(int index) {
        return houseList[index];
    }

    public int GetNumHouses() {
        return houseList.Count;
    }

    public Player AddPlayer(string name) {
        if (playerDict.Count + 1 > GetMaxPlayers())
            return null;
        Player newPlayer = new Player(name);
        playerDict.Add(name, newPlayer);
        return newPlayer;
    }

    public void AssignHouse(Player player, int house) {
        player.house = null;
        if (house == RANDOM) {
            player.house = RandomHouse();
        }
        else {
            if (!HouseIsAssigned(GetHouse(house)))
                player.house = GetHouse(house);
        }
    }

    private bool HouseIsAssigned(House house) {
        bool taken = false;
        foreach (KeyValuePair<string, Player> currPair in playerDict) {
            if (currPair.Value.house == house) {
                taken = true;
                break;
            }
        }
        return taken;
    }

    public House RandomHouse() {
        List<House> tempList = new List<House>();
        foreach (House house in houseList) {
            if (!HouseIsAssigned(house)) {
                tempList.Add(house);
            }
        }
        return tempList[Mathf.FloorToInt(Random.value * tempList.Count)];
    }

}
