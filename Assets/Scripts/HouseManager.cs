using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HouseManager {
    public const int NONE = 0;
    public const int BARATHEON = 1;
    public const int LANNISTER = 2;
    public const int STARK = 3;
    public const int GREYJOY = 4;
    public const int TYRELL = 5;
    public const int MARTELL = 6;

    private static HouseManager houseList;

    private List<House> list;

    private HouseManager() {
        list = new List<House>();
        list.Add(new House("Baratheon"));
        list.Add(new House("Lannister"));
        list.Add(new House("Stark"));
        list.Add(new House("Greyjoy"));
        list.Add(new House("Tyrell"));
        list.Add(new House("Martell"));
    }

    public static HouseManager GetInstance() {
        if (houseList == null) {
            houseList = (HouseManager) new HouseManager();
        }
        return houseList;
    }

    public House Get(int index) {
        return list[index];
    }

    public int GetNumHouses() {
        return list.Count;
    }

    public House RandomHouse() {
        return list[BARATHEON];
    }
}
