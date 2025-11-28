using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Transform content;
    [SerializeField] ScrollRect scrollRect;

    [SerializeField] GameObject talkPrefab;

    void Start()
    {
        talkPrefab = Resources.Load<GameObject>("Talk");

        inputField.ActivateInputField();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendChatting();
        }
    }

    public void SendChatting()
    {
        string message = inputField.text;

        GameObject talk = Instantiate(talkPrefab, content);

        Text text = talk.GetComponentInChildren<Text>();
        text.text = message;

        inputField.text = string.Empty;

        inputField.ActivateInputField();

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
