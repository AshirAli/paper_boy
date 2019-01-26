using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public static int speed = 5;
    public GameObject world;
    public static int points=0;
    public Transform newspaperParent;

    public GameObject newspaper;
    public Camera Main_Camera;
    public float throwDistance=2f;
    public float throwForce=5f;
    public TextMeshProUGUI pointText;

    private Vector3 Mposition;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = points.ToString();
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
        pointText.text = points.ToString();
    }

    public void PointAdd()
    {
        points += 10;
        pointText.text = points.ToString();
    }

    void ThrowNewspaper()
    {
        GameObject instance = Instantiate(newspaper,newspaperParent);
        instance.transform.position = Main_Camera.transform.position + Main_Camera.transform.forward * throwDistance;
        instance.GetComponent<Rigidbody>().useGravity = true;
        //instance.GetComponent<Rigidbody>().AddForce(new Vector3(Mposition.x * throwForce,Mposition.y * throwForce,Main_Camera.transform.forward.x*throwForce));
        instance.GetComponent<Rigidbody>().AddForce(Main_Camera.transform.forward.x * throwForce, Main_Camera.transform.forward.y * throwForce + 5, Main_Camera.transform.forward.z * throwForce);
        instance.GetComponent<Rigidbody>().velocity = Main_Camera.transform.forward * 10;
        //instance.transform.rotation += (5f, 5f, 5f);
    }
}
