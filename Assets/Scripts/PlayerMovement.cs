using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject world;
    public Transform prefabParentTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End_Trigger")
        {
            Debug.Log("New world create");
            GameObject instance = (GameObject)Instantiate(world, prefabParentTransform) as GameObject;
            instance.transform.position = new Vector3(100, 0, 0);
        }
    }
}
