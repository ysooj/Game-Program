using Photon.Realtime;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputField;

    [SerializeField] Toggle [] toggles;

    [SerializeField] int personal = 0;

    void Start()
    {
        Select(true);
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = personal;  // 방에 접속할 수 있는 최대 인원
        roomOptions.IsOpen = true;          // 방의 오픈 여부
        roomOptions.IsVisible = true;       // 방의 활성화 여부

        PhotonNetwork.CreateRoom(titleInputField.text, roomOptions);

        gameObject.SetActive(false);
    }

    public void Select(bool power)
    {
        if (power == false) { return; }

        if (toggles[0].isOn)
        {
            personal = 2;
        }
        else if (toggles[1].isOn)
        {
            personal = 3;
        }
        else if (toggles[2].isOn)
        {
            personal = 4;
        }
    }

    public void Cancle()
    {
        gameObject.SetActive(false);
    }
}