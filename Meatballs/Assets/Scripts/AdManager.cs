using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    [SerializeField]
    string gameID = "1075565";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ShowAd()
    {
       // StartCoroutine(WaitForAd());
        //Debug.Log("ready? " + Advertisement.IsReady("rewardedVideoZone"));
        if (Advertisement.IsReady()) {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show();
            //Advertisement.Show("rewardedVideoZone", options);
        }
    }

    void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Finished. Rewarding player...");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }

    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }
}