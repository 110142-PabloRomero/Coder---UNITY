using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private string time;
    [SerializeField] private float timer;
    public Text timerText;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        
        time = "Time: ";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0)
        {

            timer -= Time.deltaTime;

            timerText.text = time + timer.ToString("f0");

        }

        if (timer <= 0)
        {
            go.SetActive(true);
        }

    }
}
