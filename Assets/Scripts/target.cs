using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    [SerializeField] float _minForce = 12f;
    [SerializeField] float _maxForce = 16f;
    [SerializeField] float _xRange = 4f;
    [SerializeField] float _yPos = -2f;
    [SerializeField] float _torque = 10f;

    [SerializeField] int scoreValue;

    [SerializeField] ParticleSystem explosionParticle;

    GameManager gameManager;

    Rigidbody targetRB;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(randomUpFor(), ForceMode.Impulse);
        targetRB.AddTorque(ranTorque(), ranTorque(), ranTorque(), ForceMode.Impulse);
        transform.position = randomXPos();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    Vector3 randomUpFor()
    {
        return Vector3.up * Random.Range(_minForce, _maxForce);
    }

    float ranTorque(){
        return Random.Range(-_torque, _torque);
    }

    Vector3 randomXPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _yPos);
    }


    void OnMouseDown(){
        Destroy(gameObject);
        gameManager.updateScore(scoreValue);
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Sensor")){
            Destroy(gameObject);
        }

        if(!gameObject.CompareTag("Bad") && other.CompareTag("Sensor")){
            gameManager.gameOver();
        }
    }

    
}
