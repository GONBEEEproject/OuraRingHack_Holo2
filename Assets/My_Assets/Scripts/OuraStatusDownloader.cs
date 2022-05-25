using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OuraStatusDownloader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetStatus());
    }

    private IEnumerator GetStatus()
    {

        using (var req = UnityWebRequest.Get("https://api.ouraring.com/v2/usercollection/personal_info"))
        {
            req.SetRequestHeader("host", "api.ouraring.com");
            req.SetRequestHeader("authorization", "Bearer " + StaticTokenHolder.TOKEN);

            yield return req.SendWebRequest();

            try
            {
                Debug.Log(req.downloadHandler.text);
            }
            catch
            {
                Debug.Log(req.error);
            }
        }

        using (var req = UnityWebRequest.Get("https://cloud.ouraring.com/v2/usercollection/daily_activity"))
        {
            req.SetRequestHeader("host", "api.ouraring.com");
            req.SetRequestHeader("authorization", "Bearer " + StaticTokenHolder.TOKEN);

            yield return req.SendWebRequest();

            try
            {
                Debug.Log(req.downloadHandler.text);
            }
            catch
            {
                Debug.Log(req.error);
            }
        }

        using (var req = UnityWebRequest.Get("https://cloud.ouraring.com/v2/usercollection/heartrate"))
        {
            req.SetRequestHeader("host", "api.ouraring.com");
            req.SetRequestHeader("authorization", "Bearer "+StaticTokenHolder.TOKEN);

            yield return req.SendWebRequest();

            try
            {
                Debug.Log(req.downloadHandler.text);
            }
            catch
            {
                Debug.Log(req.error);
            }
        }
    }
}
