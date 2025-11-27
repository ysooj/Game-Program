using UnityEngine;
using Photon.Pun;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    [SerializeField] float minimumAngle = -65;
    [SerializeField] float maximumAngle = 65;

    void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            rotation.RotateX(minimumAngle, maximumAngle);
        }
    }
}
