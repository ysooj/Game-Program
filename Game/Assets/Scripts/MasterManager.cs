using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class MasterManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5);
    private Coroutine spawnCoroutine;

    void Start()
    {
        restartSpawn();
    }

    void restartSpawn()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            if(spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
            spawnCoroutine = StartCoroutine(SpawnRoutine());
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.InstantiateRoomObject("Ball", Vector3.zero, Quaternion.identity);
            }
            
            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        restartSpawn();
    }
}