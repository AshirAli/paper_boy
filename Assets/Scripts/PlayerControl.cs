using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed = 5;
    public GameObject world;
    public static int points=0;
    public Transform newspaperParent;

    public GameObject newspaper;
    public Camera Main_Camera;
    public float throwDistance=2f;
    public float throwForce=5f;

    private Vector3 Mposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //newspaper.transform.position = Main_Camera.transform.position + Main_Camera.transform.forward * throwDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        world.transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
        if (Input.GetMouseButtonDown(0))
        {
            Mposition = Main_Camera.ScreenToWorldPoint(Input.mousePosition);
            ThrowNewspaper();
        }
    }

    public void PointAdd()
    {
        points += 10;
        Debug.Log(points);
    }

    void ThrowNewspaper()
    {
        GameObject instance = Instantiate(newspaper,newspaperParent);
        instance.transform.position = Main_Camera.transform.position + Main_Camera.transform.forward * throwDistance;
        instance.GetComponent<Rigidbody>().useGravity = true;
        //instance.GetComponent<Rigidbody>().AddForce(new Vector3(Mposition.x * throwForce,Mposition.y * throwForce,Main_Camera.transform.forward.x*throwForce));
        instance.GetComponent<Rigidbody>().AddForce(Main_Camera.transform.forward * throwForce);
        //instance.transform.rotation += (5f, 5f, 5f);
        Debug.Log("Throw!");
    }
}
