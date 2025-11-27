using UnityEngine;
using Photon.Pun;
using UnityEditor.Experimental.GraphView;

public class Character : MonoBehaviourPun
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] CharacterController characterController;

    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    [SerializeField] Rotation rotation;
    [SerializeField] Head head;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rotation = GetComponent<Rotation>();
    }

    void Start()
    {
        DisableCamera();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Control();

            Move();

            rotation.RotateY();
        }
    }

    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }

    public void Control()
    {
        direction.x = Input.GetAxis("Horizontal");  // A, D
        direction.z = Input.GetAxis("Vertical");    // W, S

        // direction 방향을 단위 벡터로 설정합니다.
        direction.Normalize();
    }

    public void Move()
    {
        characterController.Move(characterController.transform.TransformDirection(direction) * speed * Time.deltaTime);
    }
}

// CharacterController
// 입력 - direction
// charaterController.Move