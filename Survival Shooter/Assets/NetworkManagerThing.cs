using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerThing : NetworkManager {

	[SerializeField]
	GameObject[] playerCharacterPrefabs;

	short playerControllerHighestId = 3;

	void OnGUI()
	{
		if(GUI.Button(new Rect(10, Screen.height - 60, 400, 50), "spawn a new character of mine"))
		{
			// pay attention here !!
			ClientScene.AddPlayer(client.connection, playerControllerHighestId++);
		}
	}

	public override void OnStartClient (NetworkClient client)
	{
		base.OnStartClient (client);

		// always remember to register prefabs before spawning them.
		foreach(GameObject go in playerCharacterPrefabs)
			ClientScene.RegisterPrefab(go);

		Debug.Log("Connect to a new game");

	}

	public override void OnClientConnect (NetworkConnection conn)
	{
		base.OnClientConnect (conn);
	}

	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{
		GameObject newPlayer = GameObject.Instantiate(playerCharacterPrefabs[playerControllerId%1]);
		newPlayer.transform.position = Vector3.zero + Vector3.right * playerControllerId;
		NetworkServer.Spawn(newPlayer);

		// object spawned via this function will be a local player
		// which belongs to the client connection who called the ClientScene.AddPlayer
		NetworkServer.AddPlayerForConnection(conn, newPlayer, playerControllerId);
	}

}
