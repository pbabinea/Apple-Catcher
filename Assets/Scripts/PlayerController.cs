using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public int score = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject plate1;
    public GameObject plate2;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        //used to keep player in bounds
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal mouse movement
        if (Time.timeScale != 0)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = transform.position.z;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }

        scoreText.text = "Score:\n " + score;
    }

    void LateUpdate()
    {
        //used to keep player in bounds
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }

    //consume apple
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.tag.Equals("Apple") || collision.gameObject.tag.Equals("GreenApple"))
        {
            AppleCollision(collision);
        }
    }

    public void AppleCollision(Collision2D collision)
    {
        //Debug.Log("player get apple");
        if (collision.gameObject.tag.Equals("Apple"))
            AddPoints(100);
        else if (collision.gameObject.tag.Equals("GreenApple"))
            AddPoints(200);
        //Debug.Log("score: " + score);

        //increase difficulty based on score
        if (score >= 1000 && score % 500 == 0)
            Manager.instance.generator.GetComponent<AppleGenerator>().IncreaseDifficulty();
        Destroy(collision.gameObject);
    }

    public void AddPoints(int pts)
    {
        score += pts;
    }

    public void LoseLife()
    {
        if (lives == 3)
        {
            lives -= 1;
            Destroy(plate1.gameObject);
        }
        else if (lives == 2)
        {
            lives -= 1;
            Destroy(plate2.gameObject);
        }
        else
            Manager.instance.EndGame(score);
    }
}
