using Photon.Realtime;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField titleInputField;

    [SerializeField] Button[] buttons;

    [SerializeField] int personal = 0;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);

        buttons[0].onClick.Invoke();
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = personal;  // 방에 접속할 수 있는 최대 인원
        roomOptions.IsOpen = true;          // 방의 오픈 여부
        roomOptions.IsVisible = true;       // 방의 활성화 여부

        PhotonNetwork.CreateRoom(titleInputField.text, roomOptions);
    }

    public void Select(int count)
    {
        personal = count;
    }

    public void Cancle()
    {
        gameObject.SetActive(false);
    }
}