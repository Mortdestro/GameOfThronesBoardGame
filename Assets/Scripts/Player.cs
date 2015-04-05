using UnityEngine;
using System.Collections;

public class Player {

    public string name;
    private House house;

    public Player(string name) {
        this.name = name;
    }

    public Player(string name, House house) {
        this.name = name;
        this.house = house;
    }

    public House GetHouse() {
        return this.house;
    }

    public void SetHouse(House house) {
        this.house = house;
    }
}
