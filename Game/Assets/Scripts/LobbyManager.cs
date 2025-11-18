using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dictionary<string, GameObject> dictionary = new();

    public override void OnRoomListUpdate (List<RoomInfo> roomList)
    {
        // 룸이 삭제된 경우
        // 룸의 정보가 변경되는 경우
        // 룸이 처음 생성되는 경우

        GameObject prefab = null;


    }
}
