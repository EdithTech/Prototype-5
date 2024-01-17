using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI gameStartText;
    [SerializeField] Button restart;
    [SerializeField] Button easy;
    [SerializeField] Button medium;
    [SerializeField] Button hard;
    public int score = 0;
    float _spawnRate = 1f;
    bool isGameOver = false;


    public void startGame(int difficulty){
        StartCoroutine(spawn());
        updateScore(0); 
        gameStartText.gameObject.SetActive(false);
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        _spawnRate /= difficulty;
        
    }

    void Update(){
        if(score < 0){
            gameOver();
        }
    }

    IEnumerator spawn(){
        while(!isGameOver){
            int ind = Random.Range(0, targets.Count);
            Instantiate(targets[ind]);
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    public void updateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score : " + score;
    }

    public void gameOver(){
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
