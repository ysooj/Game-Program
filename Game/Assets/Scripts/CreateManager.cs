using Photon.Pun;
using UnityEngine;

public class CreateManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.Instantiate("Character", Vector3.zero, Quaternion.identity);

    }
}