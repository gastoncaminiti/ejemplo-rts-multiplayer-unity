using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerBasic : NetworkManager
{


    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        NetworkPlayer player = conn.identity.GetComponent<NetworkPlayer>();

        player.SetDisplayName($"Player {numPlayers}");
        player.SetDisplayColor(new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
    }

}
