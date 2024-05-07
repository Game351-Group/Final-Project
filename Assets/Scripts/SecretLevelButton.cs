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
        if(playerSystem.score == 14){
            Debug.Log("True");
            SceneManager.LoadScene("HiddenLevel");
        }else{
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        HiddenText.gameObject.SetActive(true);
        HiddenBack.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        HiddenText.gameObject.SetActive(false);
        HiddenBack.gameObject.SetActive(false);
    }
}
