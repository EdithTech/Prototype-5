using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]


public class clickAndSwipe : MonoBehaviour
{
    GameManager gameManager;
    Camera cam;
    Vector3 mousePos;

    TrailRenderer trail;
    BoxCollider col;

    bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();

        trail.enabled = false;
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                updateComponent();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                updateComponent();
            }

            if (swiping)
            {
                updateMousePos();
            }
            else
            {
                trail.Clear();
            }
        }
    }

    void updateMousePos()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }

    void updateComponent()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<target>())
        {
            
            other.gameObject.GetComponent<target>().DestroyTarget();
        }
    }

}
