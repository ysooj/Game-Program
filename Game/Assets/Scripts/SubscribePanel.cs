using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SubscribePanel : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField nameInput;
    [SerializeField] InputField addressInput;
    [SerializeField] InputField passwordInput;
    [SerializeField] Text subscribeText;

    public void Subscribe()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = addressInput.text,
            Password = passwordInput.text,
            Username = nameInput.text
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            Success,
            Failure
        );
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        gameObject.SetActive(false);
    }

    public void Failure(PlayFabError playFabError)
    {
        PanelManager.Instance.Load(Panel.Error, playFabError.GenerateErrorReport());
    }
}
