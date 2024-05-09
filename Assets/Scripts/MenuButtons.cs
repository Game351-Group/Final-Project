using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;
    void Start(){
        Cursor.visible = true;
    }
    public void LoadCutScene()
    {
        click.PlayOneShot(click.clip, .7f);
        SceneManager.LoadScene("CutScene");
    }
    public void LoadMainMenu()
    {
        click.PlayOneShot(click.clip, .7f);
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGame()
    {
        click.PlayOneShot(click.clip, .7f);
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        click.PlayOneShot(click.clip, .7f);
        Application.Quit();
    }
}
