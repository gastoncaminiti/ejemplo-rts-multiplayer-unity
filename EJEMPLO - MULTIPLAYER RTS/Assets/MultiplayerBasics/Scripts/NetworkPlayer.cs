using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text displayNameText = null;
    [SerializeField] private Renderer displayColourRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdated))]
    [SerializeField]
    private string displayName = "DefaultName";

    [SyncVar(hook = nameof(HandleDisplayColourUpdated))]
    [SerializeField]
    private Color displayColor;

    #region Server

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        displayColor = newDisplayColor;
    }

    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        //lenght > 2 
        if (newDisplayName.Length < 2) { return; }
        SetDisplayName(newDisplayName);
    }

    [ContextMenu("Set My Name from Server in Cliente")]
    private void SetMyNameServer()
    {
        RpcSetDisplayName("Server Name");
    }

    #endregion

    #region Client

    private void HandleDisplayColourUpdated(Color oldColour, Color newColour)
    {
        displayColourRenderer.material.SetColor("_Color", newColour);
    }

    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displayNameText.text = newName;
    }

    [ContextMenu("Set My Name from Client in Server")]
    private void SetMyNameClient()
    {
        CmdSetDisplayName("C");
    }

    [ClientRpc]
    private void RpcSetDisplayName(string newDisplayName)
    {
        SetDisplayName(newDisplayName);
    }

    #endregion
}
