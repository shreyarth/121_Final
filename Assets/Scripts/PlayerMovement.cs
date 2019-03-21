using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*Sources:
 * Music: https://freesound.org/people/djgriffin/sounds/172561/
 * Snake tutorial: https://www.youtube.com/watch?v=8ztq9fQT6Kc
 * Gravity of planet: https://www.youtube.com/watch?v=gHeQ8Hr92P4
*/
public class Tag
{
    public enum PlayerDirection
    {
        LEFT = 0,
        UP = 1,
        RIGHT = 2,
        DOWN = 3,
        COUNT = 4
    }
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject tail;

    public Tag.PlayerDirection dir;
    private List<Rigidbody> node;

    #region player
    private Rigidbody rb;
    public float speed;
    private bool create_node;
    public Text scoreText;
    public Text gameOver;
    public Text win;
    private int score;
    public float rotationSpeed;
    public GameObject f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15;
    #endregion

    #region Doors
    public Animator d1;
    public Animator d2;
    public Animator d3;
    #endregion


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameOver.enabled = false;
        win.enabled = false;
        ScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        //CreateNode();
    }
    void FixedUpdate()
    {
        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //Rotation
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * -rotationSpeed);
        }
        if(score == 5)
        {
            d1.SetBool("open", true);
        }
        if (score == 10)
        {
            d2.SetBool("open", true);
        }
        if (score == 15)
        {
            d3.SetBool("open", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruits"))
        {
            Destroy(other.gameObject);
            score += 1;
            ScoreText();
            create_node = true;
        }
    }
    void ScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver.enabled = true;
            gameOver.text = "GameOver!";
            rb.velocity = new Vector3(0f, 0f, 0f);
            StartCoroutine("Wait");
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            win.enabled = true;
            StartCoroutine("Win");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Lose");
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Win");
    }

    #region commented
    /*
    void Makenode()
    {
        node = new List<Rigidbody>();
        node.Add(transform.GetChild(1).GetComponent<Rigidbody>());
        node.Add(transform.GetChild(2).GetComponent<Rigidbody>());
        head = node[1];
    }

    void CreateNode()
    {
        if (create_node)
        {
            create_node = false;
            GameObject newNode = Instantiate(tail, node[1].position, Quaternion.identity);
            newNode.transform.SetParent(head.transform, true);
            node.Add(newNode.GetComponent<Rigidbody>());
        }
    }
    */
    #endregion
}
