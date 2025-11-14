using UnityEngine;
using Photon.Pun;
using PlayFab;
using UnityEngine.UI;
using Photon.Realtime;
using PlayFab.ClientModels;
using System.Collections;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField addressInputField;
    [SerializeField] InputField passwordInputField;

    // 로그인이 성공했을 때 호출되는 함수
    public void Success(LoginResult loginResult)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        StartCoroutine(Connect());
    }

    // 로비에 접속했을 때 호출되는 함수
    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    // 서버에 연결하는 코루틴 함수
    private IEnumerator Connect()
    {
        // Name Server에서 Master Server로 넘어가는 중...
        PhotonNetwork.ConnectUsingSettings();

        // 서버 연결이 완료되거나 시간 초과될 때까지 대기
        while (PhotonNetwork.IsConnectedAndReady == false)
        {
            yield return null;
        }

        // 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby();
    }

    // 이메일과 비밀번호로 로그인 시도
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = addressInputField.text,
            Password = passwordInputField.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
            request,
            Success,
            Failure
        );
    }

    // 로그인이 실패했을 때 호출되는 함수
    public void Failure(PlayFabError playFabError)
    {
        //Debug.Log(playFabError.GenerateErrorReport());

        PanelManager.Instance.Load(Panel.Error, playFabError.GenerateErrorReport());
    }
}