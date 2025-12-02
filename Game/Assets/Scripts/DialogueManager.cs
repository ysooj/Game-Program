using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;
    [SerializeField] ScrollRect scrollRect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   // Enter 키를 눌렀을 때
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0)
            {
                return;
            }

            //GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"), parentTransform);
            //talk.GetComponent<Text>().text = inputField.text;

            // string talk = inputField.text;
            string talk = PhotonNetwork.LocalPlayer.NickName + " : " + inputField.text;
            // string nickname = PhotonNetwork.LocalPlayer.NickName;

            // RPC Target.All : 현재 룸에 있는 모든 클라이언트에게 Talk() 함수를 실행하라는 명령을 전달합니다.
            photonView.RPC("Send", RpcTarget.All, talk);

            // inputField의 텍스트를 초기화합니다.
            inputField.text = "";

            // 채팅을 입력한 후에도 이어서 입력을 할 수 있도록 설정합니다.
            inputField.ActivateInputField();
        }
    }

    [PunRPC]    // 원격 호출 메서드
    public void Send (string message)
    {
        // prefab을 하나 생성한 다음 text에 값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("Talk"));

        // prefab 오브젝트의 Text 컴포넌트로 접근해서 text의 값을 설정합니다.
        talk.GetComponent<Text>().text = message;

        // 스크롤 뷰 - content 오브젝트의 자식으로 등록합니다.
        talk.transform.SetParent(parentTransform);

        // 스크롤을 맨 아래로 내리는 코드
        // 모든 Canvas의 레이아웃을 최신 상태로 강제 업데이트 (콘텐트의 크기는 최신 상태, 스크롤 길이는 정확한 상태)
        // Canvas를 수동으로 동기화 시킵니다.
        Canvas.ForceUpdateCanvases();
        // 스크롤 뷰의 세로 위치를 맨 아래로 설정
        // 스크롤의 위치를 초기화합니다.
        scrollRect.verticalNormalizedPosition = 0f; // 0f는 맨 아래, 1f는 맨 위
    }
}
