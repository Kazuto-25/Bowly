using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Behaviour : MonoBehaviour
{
    [Header("Component Refs")]
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    [Header("Obj Refs")]
    [SerializeField] private GameObject landingParticlePrefab;
    [SerializeField] private GameObject[] checkPoints;
    [SerializeField] private GameObject nextLevelPortal;
    [SerializeField] private GameObject GameEnd_Panel;
    [SerializeField] private Slider distanceSlider;

    [Header("Movement Vars")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float breakPoint;
    [SerializeField] private float maxDistance;
    [SerializeField] private bool canJump;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private int NextLevel;

    [Header("Landing Particle Vars")]
    [SerializeField] private Vector2 landingParticleOffset = new Vector2(0f, -0.5f);

    private Transform currentCheckpoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.AddForce(Vector2.right * 4, ForceMode2D.Impulse);

        SetInitialCheckpoint();

        if (distanceSlider != null)
        {
            distanceSlider.maxValue = maxDistance;
            distanceSlider.minValue = 0f;
        }

        GameEnd_Panel.SetActive(false);
    }

    private void Update()
    {
        if (transform.position.y < breakPoint)
        {
            RespawnAtCheckpoint();
        }

        float distanceToPortal = GetDistanceToPortal();

        if (distanceSlider != null)
        {
            distanceSlider.value = distanceToPortal;
        }
    }

    public void MoveLeft()
    {
        rb.AddForce(Vector2.left * speed);
    }

    public void MoveRight()
    {
        rb.AddForce(Vector2.right * speed);
    }

    public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            rb.AddForce(Vector2.up * (jumpForce / 2), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            InstantiateLandingParticle(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
        }

        if (collision.CompareTag("PortalOpener"))
        {
            ActivatePortal(true);
        }

        if (collision.CompareTag("WinTag"))
        {
            SceneManager.LoadScene(NextLevel);
        }

        if (collision.CompareTag("FinalPortal"))
        {
            spriteRenderer.enabled = false;
            rb.velocity = Vector2.zero;
            GameEnd_Panel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalOpener"))
        {
            ActivatePortal(false);
        }
    }

    private void RespawnAtCheckpoint()
    {
        if (currentCheckpoint != null)
        {
            transform.position = currentCheckpoint.position;
            rb.velocity = Vector2.zero;
        }
    }

    private void SetInitialCheckpoint()
    {
        if (checkPoints.Length > 0)
        {
            currentCheckpoint = checkPoints[0].transform;
        }
    }

    private void ActivatePortal(bool activated)
    {
        if (activated)
        {
            nextLevelPortal.SetActive(true);
        }
        else
        {
            nextLevelPortal.SetActive(false);
        }
    }

    private void InstantiateLandingParticle(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector3 landingPosition = contact.point + (Vector2)landingParticleOffset;
        Instantiate(landingParticlePrefab, landingPosition, Quaternion.identity);
    }

    private float GetDistanceToPortal()
    {
        if (nextLevelPortal != null)
        {
            return Vector2.Distance(transform.position, nextLevelPortal.transform.position);
        }
        return 0f;
    }
}
