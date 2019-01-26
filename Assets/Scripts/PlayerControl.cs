using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed = 5;
    public GameObject world;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        world.transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
    }
}
