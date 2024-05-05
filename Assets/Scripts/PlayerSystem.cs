using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public int save = 0; // Must start at 0
    public int life = 9; // Start at 9
    public int score = 0;
    private IngameUI ingameUI;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        ingameUI = GameObject.Find("Canvas").GetComponent<IngameUI>();
        gameManager = GameObject.Find("Fog").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add Event when player has no life point
        if(life == 0){
            Debug.Log("Dead");
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
        // More Save Points can be added

        // When player hits a collectable item, score will be increased
        if(other.tag == "Collectable" ) {
            ingameUI.getScore(++score); // Update UI
            other.gameObject.SetActive(false);
        }

        // When player hits a obstacle, player loses 1 life and respawn
        if(other.tag == "Obstacles" ) {
            ingameUI.LoseLife(--life);
            gameManager.respawn(gameObject);
        }
    }
}
