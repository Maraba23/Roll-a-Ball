using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public AudioSource collectSound;
    public GameObject MainCamera;
    private int count;
    private bool win;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        count = SpawnerSelector.count;
        rb = GetComponent <Rigidbody>();
        SetCountText();
        win = false;
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

   void SetCountText()
   {
       countText.text = "Count: " + count.ToString();
       if (count == 0)
       {
            winTextObject.SetActive(true);
            StartCoroutine(WaitAndLoadMenu());
       }
   }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (!win)
            timerText.text = "Time: " + Time.timeSinceLevelLoad.ToString("F2");
        if (EnemyController.isDead)
        {
            loseTextObject.SetActive(true);
        }
    }

   private void FixedUpdate()
   {
        Vector3 movement = new Vector3 (MainCamera.transform.forward.x * movementY, 0.0f, MainCamera.transform.forward.z * movementY) + new Vector3 (MainCamera.transform.right.x * movementX, 0.0f, MainCamera.transform.right.z * movementX);
        rb.AddForce(movement * speed);
   }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            collectSound.Play();
            count--;
            SetCountText();
        }
        
    }
}
