using UnityEngine;
using System.Collections;

public class Player {

    public string name;
    public House house;

    public Player(string name) {
        this.name = name;
    }

    public Player(string name, House house) {
        this.name = name;
        this.house = house;
    }
}
