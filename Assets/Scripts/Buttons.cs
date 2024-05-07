using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;
    void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
