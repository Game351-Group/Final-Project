using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AfterCutScene : MonoBehaviour
{
    // This script loads the game scene or victory scene after the cutscene ends
    // Start is called before the first frame update
    public string nextSceneName;
    private PlayableDirector director;
    void Start()
    {
        PlayableDirector director = GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped += DirectorStopped;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
    private void DirectorStopped(PlayableDirector director)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnDestroy()
    {
        PlayableDirector director = GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped -= DirectorStopped;
        }
    }
}
