using UnityEngine;
using Photon.Pun;

public class PausePanel : MonoBehaviourPunCallbacks
{
    public void Continue()
    {
        Debug.Log("Continue 눌림");
        // 일시정지 패널 닫기
        gameObject.SetActive(false);

        MouseManager.Instance.SetMouse(false);
    }

    public void Quit()
    {
        Debug.Log("Quit 눌림");
        // 룸 나가기
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        // 로비로 돌아가기
        PhotonNetwork.LoadLevel("Lobby");
    }
}