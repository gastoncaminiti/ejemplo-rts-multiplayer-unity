using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
   [SyncVar] 
   [SerializeField]
   private string displayName = "DefaultName";
}
