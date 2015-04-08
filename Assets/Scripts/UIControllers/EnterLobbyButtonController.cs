using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterLobbyButtonController : MonoBehaviour {

    public PlayerData playerData;
    public InputField inputField;
    public GameObject thisMenu;
    public GameObject nextMenu;

    public void OnClick() {
        if (inputField.text != "") {
            playerData.SetPlayerName(inputField.text);
            nextMenu.gameObject.SetActive(true);
            thisMenu.gameObject.SetActive(false);
        }
    }
}
