using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    float _spawnRate = 1f;

    void Start(){
        StartCoroutine(spawn());
    }

    IEnumerator spawn(){
        while(true){
            int ind = Random.Range(0, targets.Count);
            Instantiate(targets[ind]);
            yield return new WaitForSeconds(_spawnRate);
        }
    }
}
