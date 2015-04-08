using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
    public GameData gameData;
    public PlayerData playerData;

    private const string TYPE_NAME = "GameOfThronesBoardGame";
    private const string GAME_NAME = "The Game";

    private HostData[] hostList;

    void Start() {
        DontDestroyOnLoad(this);
    }

    public void StartServer() {
        if (!Network.isClient && !Network.isServer) {
            Network.InitializeServer(gameData.maxPlayers, 25000, !Network.HavePublicAddress());
            MasterServer.RegisterHost(TYPE_NAME, GAME_NAME);
        }
        gameData.AddPlayer(playerData.GetPlayer());
    }

    [RPC] void AddPlayer(string name) {
        gameData.AddPlayer(new Player(name));
    }

    void OnServerInitialized() {
        Debug.Log("Server initialized");
    }

    public void RefreshHostList() {
        MasterServer.RequestHostList(TYPE_NAME);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent) {
        if (msEvent == MasterServerEvent.HostListReceived)
            hostList = MasterServer.PollHostList();
    }

    public void JoinServer(HostData hostData) {
        Network.Connect(hostData);
    }

    void OnConnectedToServer() {
        Debug.Log("Server Joined");
        GetComponent<NetworkView>().RPC("AddPlayer", RPCMode.Server, playerData.GetPlayer().name);
    }

    void OnGUI() {
        if (hostList != null) {
            for (int i = 0; i < hostList.Length; i++) {
                if (GUI.Button(new Rect(100, 100 + (50 * i), 160, 30), hostList[i].gameName))
                    JoinServer(hostList[i]);
            }
        }
    }
}
