using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    [SerializeField] float _minForce = 12f;
    [SerializeField] float _maxForce = 16f;
    [SerializeField] float _xRange = 4f;
    [SerializeField] float _yPos = -6f;
    [SerializeField] float _torque = 10f;

    Rigidbody targetRB;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(randomUpFor(), ForceMode.Impulse);
        targetRB.AddTorque(ranTorque(), ranTorque(), ranTorque(), ForceMode.Impulse);
        transform.position = randomXPos();
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
    }



    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _yPos){
            Destroy(gameObject);
        }
       
    }

    
}
