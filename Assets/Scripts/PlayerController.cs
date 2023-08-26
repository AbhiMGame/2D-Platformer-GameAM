using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] public GameObject particleSys;
    [SerializeField] private float speed;
    [SerializeField] private float force;
    [SerializeField] private bool isPlayerGrounded;
    [SerializeField] private GameObject playerPosition;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameObject worldLimiter;
    
    public GameObject gameOver;
    

    private void Awake()
    {
        gameOver.SetActive(false);
        particleSys.SetActive(false);

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        MoveCharachtar(horizontal);
        PlayMovementAnimation(horizontal);
        
        float vertical = Input.GetAxisRaw("Vertical");
        if (isPlayerGrounded == true)
        {
            JumpPlayer(vertical);
        }
    }

    private void MoveCharachtar(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        
    }

    private void JumpPlayer(float vertical)
    {
        Vector3 position = transform.position;
        position.y += vertical * force * Time.deltaTime;
        transform.position = position;
       
    }

    public void PickupKey()
    {
        Debug.Log("Key has been picked up"); 
        scoreController.IncreaseScore(10);
    }

    private void PlayMovementAnimation(float horizontal)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerMove);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerMove);
        }
        transform.localScale = scale;
        
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        animator.SetBool("Crouch", crouch);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("GROUND"))
        {
            isPlayerGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("WorldEnd"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerDeath);

        }

    }

    public void Effects()
    {
        particleSys.SetActive(true);
    }

    public void ShowGameOverPanel()
    {
        
        gameOver.gameObject.SetActive(true);
        this.enabled = false;
        SoundManager.Instance.Play(SoundManager.Sounds.GameOver);
    }

}
