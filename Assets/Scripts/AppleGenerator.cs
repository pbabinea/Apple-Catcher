using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject apple;
    public GameObject greenApple;
    public Transform bush;

    private float elapsed = 0f;
    private float minTime = 1.9f;
    private float maxTime = 4.5f;
    private float diffLvl = 1;
    //private float startTime;

    // Start is called before the first frame update
    void Start()
    {
         //startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        float interval = Random.Range(minTime, maxTime);
        if (elapsed >= interval)
        {
            //apple.SetActive(true);
            if (Random.Range(1, 101) % 15 == 0)
            {
                Instantiate(greenApple, bush.position, Quaternion.identity);
            }
            else Instantiate(apple, bush.position, Quaternion.identity);
            elapsed = 0f;
        }
    }
    public void IncreaseDifficulty()
    {
        if (diffLvl < 9)
        {
            Debug.Log("increasing difficulty");
            //lowers range for possible time between spawns
            minTime -= 0.2f;
            maxTime -= 0.2f;
            Manager.instance.bush.GetComponent<BushBehaviour>().SpeedUp(1.5f);
            diffLvl += 1;
        }
    }
}
