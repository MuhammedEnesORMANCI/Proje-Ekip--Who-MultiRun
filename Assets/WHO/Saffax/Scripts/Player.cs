using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 10f;
    public float jumpForce = 300f;


    private Rigidbody rb;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0f, v);
        rb.AddForce(move * speed);

        //// Zýplama
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector3.up * jumpForce);
        //}
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeadArea"))
        {
            gameManager.RestartLevel();
        }
        if (collision.gameObject.CompareTag("LevelUpdater"))
        {
            gameManager.LevelUp();
        }
    }
}