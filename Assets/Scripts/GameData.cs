using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameData : MonoBehaviour {

    public int maxPlayers = 6;

    private Dictionary<string, Player> playerDict;
    private Dictionary<string, House> houseDict;

    // Use this for initialization
    void Start() {
        this.playerDict = new Dictionary<string, Player>();
        this.houseDict = new Dictionary<string, House>();
        DontDestroyOnLoad(this);
    }

    public void InitializeHouses() {
        if (GetNumPlayers() < 3 || GetNumPlayers() > 6) {
            throw new ApplicationException("You must have 3-6 players before selecting houses.");
        }
        AddHouse("Baratheon");
        AddHouse("Lannister");
        AddHouse("Stark");
        if (GetNumPlayers() >= 4) {
            AddHouse("Greyjoy");
        }
        if (GetNumPlayers() >= 5) {
            AddHouse("Tyrell");
        }
        if (GetNumPlayers() == 6) {
            AddHouse("Martell");
        }
    }

    public int GetNumPlayers() {
        return playerDict.Count;
    }

    public int GetNumHouses() {
        return houseDict.Count;
    }

    public Dictionary<string, Player> GetPlayerDict() {
        return playerDict;
    }

    public Dictionary<string, House> GetHouseDict() {
        return houseDict;
    }

    public Player GetPlayer(string name) {
        return playerDict[name];
    }

    public House GetHouse(string name) {
        return houseDict[name];
    }

    public House AddHouse(string name) {
        House newHouse = new House(name);
        houseDict.Add(name, newHouse);
        return newHouse;
    }

    public void AddPlayer(Player player) {
        playerDict.Add(player.name, player);
    }

    public Player GetPlayerByHouse(House house) {
        if (house == null)
            return null;

        Player player = null;
        foreach (KeyValuePair<string, Player> currPair in playerDict) {
            if (currPair.Value.house == house) {
                player = currPair.Value;
                break;
            }
        }
        return player;
    }

    public House RandomHouse() {
        if (houseDict.Count == 0)
            return null;

        List<House> tempList = new List<House>();
        foreach (KeyValuePair<string, House> currPair in houseDict) {
            House house = currPair.Value;
            if (!HouseIsAssigned(house)) {
                tempList.Add(house);
            }
        }
        return tempList[Mathf.FloorToInt(UnityEngine.Random.value * tempList.Count)];
    }

    public void AssignHouse(Player player, House house) {
        player.house = null;
        if (!HouseIsAssigned(house))
            player.house = house;
    }

    public bool HouseIsAssigned(House house) {
        if (house == null)
            return false;
        return GetPlayerByHouse(house) != null;
    }
}
