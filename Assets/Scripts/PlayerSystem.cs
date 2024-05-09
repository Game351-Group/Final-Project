using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private Text HiddenText;
    [SerializeField]
    private Image HiddenBack;

    private float displayTime = 2.0f;
    public int save = 0; // Must start at 0
    public int life = 9; // Start at 9
    public int score = 0; // Must start at 0
    private IngameUI ingameUI;
    private GameManager gameManager;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        ingameUI = GameObject.Find("Canvas").GetComponent<IngameUI>();
        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add Event when player has no life point
        if(life == 0){
            SceneManager.LoadScene("Lose");
        }
    }

    void OnTriggerEnter(Collider other) {
        // When player hits a cat tower, make it as a last save point, and disable this object
        if(other.name == "CatTower1" && save < 1) {
            save = 1;
            other.gameObject.SetActive(false);
        }else if(other.name == "CatTower2" && save < 2) {
            save = 2;
            other.gameObject.SetActive(false);
        }else if(other.name == "CatTower3" && save < 3) {
            save = 3;
            other.gameObject.SetActive(false);
        }

        // When player hits a collectable item, score will be increased
        if(other.tag == "Collectable" ) {
            ingameUI.getScore(++score); // Update UI
            other.gameObject.SetActive(false);
        }

        // When player hits a obstacle, player loses 1 life and respawn
        if(other.tag == "Obstacles" ) {
            StartCoroutine(LoseControl());
            ingameUI.LoseLife(--life);
            gameManager.respawn(gameObject, false);
        }

        // When player falls into water, player loses 1 life and respawn
        if(other.tag == "Water"){
            StartCoroutine(ChangeImage());
            ingameUI.LoseLife(--life);
            gameManager.respawn(gameObject, true);
        }

        if(other.name == "hidden"){
            if(score == 16){
            SceneManager.LoadScene("HiddenLevel");
            }else{
                StartCoroutine(ShowMessage());
            }
        }
    }

    // To show the underwater image
    private IEnumerator ChangeImage() {
        Image underwaterImage = GameObject.Find("Underwater").GetComponent<Image>();
        if (underwaterImage != null) {
            underwaterImage.color = new Color(underwaterImage.color.r, underwaterImage.color.g, underwaterImage.color.b, 0.9f);
            StartCoroutine(LoseControl());
            yield return new WaitForSeconds(1);
            underwaterImage.color = new Color(underwaterImage.color.r, underwaterImage.color.g, underwaterImage.color.b, 0f);
        }
    }

    // Player will lose control for a sec
    private IEnumerator LoseControl(){
        player.enabled = false;
        yield return new WaitForSeconds(1);
        player.enabled = true;
    }

    private IEnumerator ShowMessage()
    {
        HiddenText.gameObject.SetActive(true);
        HiddenBack.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        HiddenText.gameObject.SetActive(false);
        HiddenBack.gameObject.SetActive(false);
    }
}
