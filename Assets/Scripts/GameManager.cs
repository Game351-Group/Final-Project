using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource click;
    [SerializeField]
    private GameObject save1, save2, save3, save4, save5;
    private PlayerSystem playerSystem;
    private IngameUI ingameUI;
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        playerSystem = GameObject.Find("Player").GetComponent<PlayerSystem>();
        ingameUI = GameObject.Find("Canvas").GetComponent<IngameUI>();
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        // ESC to pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;
                PauseGame();
            }
            else
            {
                Cursor.visible = false;
                pauseUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    // Respawn
    public void respawn(GameObject playerObject, bool water, bool hidden) {
        StartCoroutine(StartRespawn(playerObject, water, hidden));
    }

    // After die, player will respawn after 1 sec
    IEnumerator StartRespawn(GameObject playerObject, bool water, bool hidden) {
        if(water){
            yield return new WaitForSeconds(1);
        }
        Rigidbody rb = playerObject.GetComponent<Rigidbody>();
        if(hidden){
            switch (playerSystem.save) {
            case 0:
                playerObject.transform.position = new Vector3(44.02f, 16.13f, -0.02f); // Hidden Start Location
                break;
            case 1:
                playerObject.transform.position = save1.transform.position;
                break;
            case 2:
                playerObject.transform.position = save2.transform.position;
                break;
            default:
                Debug.Log("Save Point value is wrong! The initial value has to be 0");
                break;
            }
        }else{
            switch (playerSystem.save) {
            case 0:
                playerObject.transform.position = new Vector3(29.49f, 4.877f, 26.64f); // Start Location
                break;
            case 1:
                playerObject.transform.position = save1.transform.position;
                break;
            case 2:
                playerObject.transform.position = save2.transform.position;
                break;
            case 3:
                playerObject.transform.position = save3.transform.position;
                break;
            case 4:
                playerObject.transform.position = save4.transform.position;
                break;
            case 5:
                playerObject.transform.position = save5.transform.position;
                break;
            default:
                Debug.Log("Save Point value is wrong! The initial value has to be 0");
                break;
            }
        }
        // To stop previous movement
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        click.PlayOneShot(click.clip, .7f);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        click.PlayOneShot(click.clip, .7f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        click.PlayOneShot(click.clip, .7f);
        Application.Quit();
    }
}
