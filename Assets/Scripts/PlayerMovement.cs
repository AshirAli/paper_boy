using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject world;
    //public Transform prefabParentTransform;

    public GameObject world1;
    public GameObject world2;

    private bool world1enter = true, world2enter = false;
    private float xcord;
    // Start is called before the first frame update
    void Start()
    {
        //xcord = world.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End_Trigger")
        {
            if (world1enter)
            {
                world1.transform.position += world2.transform.position + new Vector3(550, 0, 0);
                world1enter = false;
                world2enter = true;
            }
            if (world2enter)
            {
                world2.transform.position += world1.transform.position + new Vector3(550, 0, 0);
                world2enter = false;
                world1enter = true;
            }
            Debug.Log("New world create");

            //GameObject instance = (GameObject)Instantiate(world, prefabParentTransform) as GameObject;
            //instance.transform.position = new Vector3(xcord+347, 0, 0);
        }
    }
}
