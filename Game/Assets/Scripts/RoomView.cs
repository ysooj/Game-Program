using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomView : MonoBehaviourPunCallbacks
{
    [SerializeField] Text roomText;
    [SerializeField] Button button;

    [SerializeField] string titleText;

    [SerializeField] RoomInfo roomInfo;

    public event System.Action OnEntered;

    private void Start()
    {
        OnEntered += UpdateRoomStatus;
    }

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(titleText);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        PanelManager.Instance.Load(Panel.Error, message);
    }

    //public void UpdateRoomInformation(string roomTitle, int currentPlayer, int maxPlayer)
    public void UpdateRoomInformation(RoomInfo roomInfo)
    {
        this.roomInfo = roomInfo;

        titleText = roomInfo.Name;
        // [ RoomInfo 자체를 매개변수로 넣는 코드 ]
        roomText.text = roomInfo.Name + " ( " + roomInfo.PlayerCount + " / " + roomInfo.MaxPlayers + " ) ";

        // 매개변수 : 방의 제목, 현재 인원, 최대 인원
        // roomInfo.PlayerCount
        // roomInfo.MaxPlayers

        // 출력 : 방의 제목 ( 현재 인원 / 최대 인원 )
        //roomText.text = $"{roomTitle} ( {currentPlayer} / {maxPlayer} )";

        OnEntered?.Invoke();
    }

    public void UpdateRoomStatus()
    {
        if (roomInfo.IsOpen)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }


    private void OnDestroy()
    {
        OnEntered -= UpdateRoomStatus;
    }
}
