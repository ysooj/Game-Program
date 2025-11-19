using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dictionary<string, GameObject> dictionary = new();
    [SerializeField] Transform parentTransform;

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate (List<RoomInfo> roomList)
    {

        GameObject prefab = null;

        foreach (RoomInfo roomInfo in roomList)
        {
            // room이 삭제된 경우
            if (roomInfo.RemovedFromList == true)
            {
                dictionary.TryGetValue(roomInfo.Name, out prefab);

                Destroy(prefab);

                dictionary.Remove(roomInfo.Name);
            }

            // 룸의 정보가 변경되는 경우
            else
            {
                // room이 처음 생성되는 경우
                if (dictionary.ContainsKey(roomInfo.Name) == false)
                { 
                    GameObject clone = Instantiate(Resources.Load<GameObject>("Room"), parentTransform);

                    clone.name = clone.name.Replace("(Clone)", "");

                    clone.GetComponent<RoomView>().UpdateRoomInformation(roomInfo);

                    dictionary.Add(roomInfo.Name, clone);
                }

                // 이미 있는 방이면 갱신하기
                else
                {
                    dictionary.TryGetValue(roomInfo.Name, out prefab);

                    prefab.GetComponent<RoomView>().UpdateRoomInformation(roomInfo);
                }
            }
        }
    }
}
