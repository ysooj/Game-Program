using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Transform content;
    [SerializeField] ScrollRect scrollRect;

    [SerializeField] GameObject talkPrefab;

    [SerializeField] Character character;

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

        character.canControl = !inputField.isFocused;
    }

    public void SendChatting()
    {
        if (string.IsNullOrWhiteSpace(inputField.text))
        {
            return;
        }

        GameObject talk = Instantiate(talkPrefab, content);

        Text text = talk.GetComponentInChildren<Text>();

        if (text == null)
        {
            Debug.LogError("Text component not found in talk prefab.");
            Destroy(talk);
            return;
        }

        text.text = inputField.text;

        inputField.text = string.Empty;

        inputField.ActivateInputField();

        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}
