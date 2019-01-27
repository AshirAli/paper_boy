using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
        

    public static int speed = 5;
    public static int WarnMeter = 100;
    public GameObject world;
    public float timeLvlIncrease=45f;
    public static int points=0;
    public Transform newspaperParent;
    public Image WarnBar;
    public GameObject newspaper;
    public Camera Main_Camera;
    public float throwDistance=2f;
    public float throwForce=5f;
    public float throwVelocity = 10f;
    public TextMeshProUGUI pointText;
    public GameObject Warning;
    public GameObject WarningEnd;
    public GameObject GameOverUI;
    public GameObject GameUI;
    public GameObject Congo1;
    public GameObject Congo2;

    private Vector3 Mposition;
    private bool enter1 = true, enter2 = true,warn1 = true , warn2 = true;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        WarnMeter = 100;
        timeLvlIncrease = 45f;
        points = 0;
        throwDistance = 2f;
        throwVelocity = 10f;
        throwForce = 5f;
        WarnBar.fillAmount = 1;
        GameUI.SetActive(true);
        Warning.SetActive(false);
        WarningEnd.SetActive(false);
        Congo1.SetActive(false);
        Congo2.SetActive(false);
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        pointText.text = points.ToString();
    }

    private void Update()
    {
        //if(Input.GetJoystickNames("OpenVR Controller - Right")
        if (Input.GetMouseButtonDown(0))
        {
            
            Mposition = Main_Camera.ScreenToWorldPoint(Input.mousePosition);
            ThrowNewspaper();
        }
        if(timeLvlIncrease < Time.time)
        {
            speed += 10;
            timeLvlIncrease += 45;
            throwForce += 10;
            throwVelocity += 10;
        }
        if(WarnMeter <= 80 & warn2 )
        {
            Warning.SetActive(true);
            Invoke("HideWarning", 2);
            warn2 = false;
        }
        if(WarnMeter <= 0 & warn1)
        {
            GameUI.SetActive(false);
            WarningEnd.SetActive(true);
            Invoke("GameOver", 2);
            warn1 = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Escape();
        }
        //newspaper.transform.position = Main_Camera.transform.position + Main_Camera.transform.forward * throwDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        world.transform.position += new Vector3(-speed*Time.deltaTime, 0, 0);
        if(points > 30 & enter1)
        {
            Congo1.SetActive(true);
            Invoke("HideCongo", 2);
            enter1 = false;
        }
        if(points > 60 & enter2)
        {
            Congo2.SetActive(false);
            Invoke("HideCongo", 2);
            enter2 = false;
        }
        pointText.text = points.ToString();
        WarnBar.fillAmount = WarnMeter / 100f;
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
        instance.GetComponent<Rigidbody>().velocity = Main_Camera.transform.forward * throwVelocity;
        //instance.transform.rotation += (5f, 5f, 5f);
    }

    void HideWarning()
    {
        Warning.SetActive(false);

    }

    void GameOver()
    {
        Main_Camera.GetComponent<MouseLook>().enabled = false;
        WarningEnd.SetActive(false);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Escape()
    {
        SceneManager.LoadScene(0);
    }

    void HideCongo()
    {
        Congo1.SetActive(false);
        Congo2.SetActive(false);
    }
}
