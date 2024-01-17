using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficultybutton : MonoBehaviour
{
    Button button;
    GameManager gameManager;
    [SerializeField] int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty(){
        Debug.Log(button.gameObject.name);
        gameManager.startGame(difficulty);
    }
}
