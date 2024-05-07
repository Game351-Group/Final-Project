using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecretLevelButton : MonoBehaviour
{
    private PlayerSystem playerSystem;
    public Text HiddenText;
    public Image HiddenBack;
    public float displayTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerSystem = GameObject.Find("Player").GetComponent<PlayerSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        // If player collected all fishes in the map
        if(playerSystem.score == 16){
            SceneManager.LoadScene("HiddenLevel");
        }else{
            StartCoroutine(ShowMessage());
        }
    }

    // Show the text box and its background
    IEnumerator ShowMessage()
    {
        HiddenText.gameObject.SetActive(true);
        HiddenBack.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        HiddenText.gameObject.SetActive(false);
        HiddenBack.gameObject.SetActive(false);
    }
}
