using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.tag.Equals("Apple") || collision.gameObject.tag.Equals("GreenApple"))
        {
            Manager.instance.player.GetComponent<PlayerController>().AppleCollision(collision);
        }
    }
}
