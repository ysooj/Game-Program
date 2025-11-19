using System.Collections.Generic;
using UnityEngine;

public enum Panel
{
    Error,
    Subscribe,
}

public class PanelManager : MonoBehaviour
{
    GameObject clone = null;

    Dictionary<Panel, GameObject> dictionary = new();

    static PanelManager instance;
    public static PanelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    // message 값을 넣으면 메시지가 표시되는 패널을 띄운다
    public void Load(Panel panel, string message)
    {
        // panel이 없으면 새로 생성 (key가 없을 경우)
        if (dictionary.TryGetValue(panel, out clone) == false)
        {
            clone = (GameObject)Instantiate(Resources.Load(panel.ToString()));

            clone.name = clone.name.Replace("(Clone)", "");

            dictionary.Add(panel, clone);
        }

        // 이미 key가 있을 경우. 즉 패널이 존재할 경우
        else
        {
            clone = dictionary[panel];

            clone.SetActive(true);
        }
    }
}