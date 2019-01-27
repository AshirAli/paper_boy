using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperMove : MonoBehaviour
{
    public GameObject AudioManager;
    public GameObject newspapers;
    public Transform basket;

    private void OnTriggerEnter(Collider other)
    {
        GameObject instance = Instantiate(newspapers, basket);
        instance.transform.position = basket.transform.position;
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

    void Disapper()
    {
        gameObject.SetActive(false);
    }
}
