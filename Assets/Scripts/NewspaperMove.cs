using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperMove : MonoBehaviour
{
    public GameObject AudioManager;
    public void Detached()
    {
        Invoke("Disappear", 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MailBox")
        {
            PlayerControl.points += 10;
            gameObject.SetActive(false);
            AudioManager.GetComponent<AudioManager>().Play("drop");
        }
        
            
       
        if(other.gameObject.tag == "House")
        {
            AudioManager.GetComponent<AudioManager>().Play("glass");
            PlayerControl.WarnMeter -= 10;
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Road")
        {
            Invoke("Disappear", 1);
        }

       
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
