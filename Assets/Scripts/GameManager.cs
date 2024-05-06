using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject save1, save2, save3;
    private PlayerSystem playerSystem;
    private IngameUI ingameUI;
    // Start is called before the first frame update
    void Start()
    {
        playerSystem = GameObject.Find("Player").GetComponent<PlayerSystem>();
        ingameUI = GameObject.Find("Canvas").GetComponent<IngameUI>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void respawn(GameObject playerObject, bool water) {
        StartCoroutine(StartRespawn(playerObject, water));
    }

    IEnumerator StartRespawn(GameObject playerObject, bool water) {
        if(water){
            yield return new WaitForSeconds(1);
        }
        Rigidbody rb = playerObject.GetComponent<Rigidbody>();

        switch (playerSystem.save) {
            case 0:
                playerObject.transform.position = new Vector3(10f, 1f, 28.91f);
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
            default:
                Debug.Log("Save Point value is wrong! The initial value has to be 0");
                break;
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
