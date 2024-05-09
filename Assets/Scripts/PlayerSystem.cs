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
     private  GameObject[] totalFish;
    // Start is called before the first frame update
    void Start()
    {
        totalFish = GameObject.FindGameObjectsWithTag("Collectable"); // Automatically count total fishes
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
        if(other != null){
            // When player hits a cat tower, make it as a last save point, and disable this object
            // Earlier save points do not overwrite later save points
            if(other.name == "CatTower1" && save < 1) {
                save = 1;
                other.gameObject.SetActive(false);
            }else if(other.name == "CatTower2" && save < 2) {
                save = 2;
                other.gameObject.SetActive(false);
            }else if(other.name == "CatTower3" && save < 3) {
                save = 3;
                other.gameObject.SetActive(false);
            }else if(other.name == "CatTower4" && save < 4) {
                save = 4;
                other.gameObject.SetActive(false);
            }else if(other.name == "CatTower5" && save < 5) {
                save = 5;
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
                gameManager.respawn(gameObject, false, false);
            }

            // When player falls into water, player loses 1 life and respawn
            if(other.tag == "Water"){
                StartCoroutine(ChangeImage(false));
                ingameUI.LoseLife(--life);
                gameManager.respawn(gameObject, true, false);
            }

            // When player falls into water, player loses 1 life and respawn
            if(other.tag == "Lava"){
                StartCoroutine(ChangeImage(true));
                ingameUI.LoseLife(--life);
                gameManager.respawn(gameObject, true, true);
            }

            // Hidden Level Checker, the score should be equal to the total fish on the map
            if(other.name == "hidden"){
                if(score == totalFish.Length){
                    SceneManager.LoadScene("HiddenLevel");
                }else{
                    StartCoroutine(ShowMessage());
                }
            }

            // Goal
            if(other.tag == "Yarn"){
                SceneManager.LoadScene("EndingCutScene");
            }

            // Hidden Goal
            if(other.name == "hiddenGoal"){
                SceneManager.LoadScene("HiddenVictory");
            }
        }
    }

    // To show the underwater or lava image
    private IEnumerator ChangeImage(bool hidden) {
        if(!hidden){
            Image underwaterImage = GameObject.Find("Underwater").GetComponent<Image>();
            if (underwaterImage != null) {
                underwaterImage.color = new Color(underwaterImage.color.r, underwaterImage.color.g, underwaterImage.color.b, 0.9f);
                StartCoroutine(LoseControl());
                yield return new WaitForSeconds(1);
                underwaterImage.color = new Color(underwaterImage.color.r, underwaterImage.color.g, underwaterImage.color.b, 0f);
            }
        }else{
            Image underlavaImage = GameObject.Find("UnderLava").GetComponent<Image>();
            if (underlavaImage != null) {
                underlavaImage.color = new Color(underlavaImage.color.r, underlavaImage.color.g, underlavaImage.color.b, 0.9f);
                StartCoroutine(LoseControl());
                yield return new WaitForSeconds(1);
                underlavaImage.color = new Color(underlavaImage.color.r, underlavaImage.color.g, underlavaImage.color.b, 0f);
            }
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
