using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviour
{
    [SerializeField] Text roomText;
    [SerializeField] string titleText;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titleText);
    }

    //public void UpdateRoomInformation(string roomTitle, int currentPlayer, int maxPlayer)
    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        titleText = roomInfo.Name;
        // [ RoomInfo 자체를 매개변수로 넣는 코드 ]
        roomText.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";

        // 매개변수 : 방의 제목, 현재 인원, 최대 인원
        // roomInfo.PlayerCount
        // roomInfo.MaxPlayers

        // 출력 : 방의 제목 ( 현재 인원 / 최대 인원 )
        //roomText.text = $"{roomTitle} ( {currentPlayer} / {maxPlayer} )";
    }

    
}
