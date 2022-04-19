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

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor)
    {
        displayColor = newDisplayColor;
        //TEST NEW COLOR
        //gameObject.transform.GetChild(0).GetComponent<MeshRenderer>()
    }

    private void HandleDisplayColourUpdated(Color oldColour, Color newColour)
    {
        displayColourRenderer.material.SetColor("_Color", newColour);
    }

    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displayNameText.text = newName;
    }
}
