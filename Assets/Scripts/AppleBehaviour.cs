using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehaviour : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //falling down
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime * -1, 0);

        //remove at bottom of screen
        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
        {
            Destroy(this.gameObject);
            if (this.gameObject.tag.Equals("Apple"))
                Manager.instance.player.GetComponent<PlayerController>().LoseLife();
        }

    }
}
