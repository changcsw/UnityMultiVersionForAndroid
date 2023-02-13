using System.IO;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Networking;
#endif

public class Demo : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void OnApplicationFocus(bool isFocus)
    {
        Debug.Log("[Demo] OnApplicationFocus");

    }

    void OnApplicationPause(bool pause)
    {
        Debug.Log("[Demo] OnApplicationPause");
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public static void Init()
    {
        Debug.Log("[Demo] Init");
    }

    static byte[] LoadStreamingAssets(string path)
    {
#if UNITY_ANDROID
        using (var req = UnityWebRequest.Get(path))
        {
            req.SendWebRequest();
            while (!req.isDone)
            {
            }

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.Log(req.error);
            }
            else
            {
                return req.downloadHandler.data;
            }
        }
#endif
        FileStream stream = File.OpenRead(path);
        int length = (int) stream.Length;
        byte[] bytes = new byte[length];
        stream.Read(bytes, 0, length);
        stream.Close();
        return bytes;
    }
}