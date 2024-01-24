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
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI gameStartText;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI pauseText;

    [SerializeField] GameObject pauseScreen;

    [SerializeField] Button restart;
    [SerializeField] Button easy;
    [SerializeField] Button medium;
    [SerializeField] Button hard;

    [SerializeField] AudioClip music;
    [SerializeField] Slider volSlider;

    AudioSource musicSource;


    public int score = 0;
    public int lives = 3;
    float _spawnRate = 1f;
    
    public bool isGameOver = false;
    bool isGamePaused = false;

    void Start(){
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.Play();
    }


    public void startGame(int difficulty){
        StartCoroutine(spawn());
        updateScore(0); 
        updateLives(lives);

        gameStartText.gameObject.SetActive(false);
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);
        volumeText.gameObject.SetActive(false);
        volSlider.gameObject.SetActive(false);

        _spawnRate /= difficulty;
    }



    void Update(){
        musicSource.volume = volSlider.value;
        if(lives == 0){
            gameOver();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isGamePaused){
                pauseMenu();
                isGamePaused = true;
            }else{
                continueGame();
                isGamePaused = false;
            }
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
        if(score < 0){
            score = 0;
        }
        scoreText.text = "Score : " + score;
    }

    public void updateLives(int livesToDisplay){
        if(livesToDisplay >= 0){
            livesText.text = "lives : " + livesToDisplay;
        }
    }

    public void gameOver(){
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void pauseMenu(){
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        pauseText.gameObject.SetActive(true);
    }

    void continueGame(){
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        pauseText.gameObject.SetActive(false);
    }

    
}
