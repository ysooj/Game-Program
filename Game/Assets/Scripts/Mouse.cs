using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using System;

public class Mouse : MonoBehaviourPunCallbacks
{
    public void SetMouse(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }

    void OnDestroy()
    {
        if (photonView.IsMine)
        {
            SetMouse(true);
        }
    }
}