using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BushBehaviour : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    private float elapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += 1;
        if (!movingRight && Camera.main.WorldToViewportPoint(transform.position).x < 0+0.1)
        {
            //Debug.Log("left edge");
            ChangeDirection();
        }
        if (movingRight && Camera.main.WorldToViewportPoint(transform.position).x > 1-0.1)
        {
            //Debug.Log("right edge");
            ChangeDirection();
        }
        if (elapsed % (Random.Range(300, 400)) == 0)
            ChangeDirection();
        if (elapsed > 1000) elapsed = 0;
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void SpeedUp(float spd)
    {
        if (speed < 0)
            speed -= spd;
        else speed += spd;
        Debug.Log("bush speed: " + speed);
    }

    private void ChangeDirection()
    {
        speed *= -1;
        movingRight = !movingRight;
    }
}
