using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(-PlayerControl.speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MailBox")
        {
            PlayerControl.points += 10;
            gameObject.SetActive(false);
        }
    }
}
