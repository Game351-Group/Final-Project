using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IngameUI : MonoBehaviour
{
    public Text currentLifeText;
    public Text fishScore;
    private int totalLife;
    private PlayerSystem playerSystem;
    // Start is called before the first frame update
    void Start()
    {
        playerSystem = GameObject.Find("Player").GetComponent<PlayerSystem>();
        totalLife = playerSystem.life;
        currentLifeText.text = playerSystem.life + " / " + totalLife;
        fishScore.text = "Collected: 0";
    }


    // Update Text when player lose life, will be called on GameManager
    public void LoseLife(int life){
        currentLifeText.text = life.ToString() + " / " + totalLife;
    }

    // Update Text when player collect fish
    public void getScore(int score){
        fishScore.text = "Collected: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
