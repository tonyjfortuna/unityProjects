using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
public float thrustForce = 1f;
public float maxSpeed = 5f;
public GameObject boosterFlame;
public float scoreMultiplier = 10f;
public UIDocument uiDocument;
public GameObject explosionEffect;
public InputAction moveForward;
public InputAction lookPosition;
private Rigidbody2D rb;
private float elapsedTime = 0f;
private float score = 0f;
private Label highScoreText;
private Label scoreText;
private Button restartButton;
private float highScore;
private float? highScoreCheck;
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
{
    rb = GetComponent<Rigidbody2D>();

    highScoreCheck = PlayerPrefs.GetFloat("highScore");
    if ((highScoreCheck == null) || (highScoreCheck == 0f))
    {
        highScore = 0f;
        PlayerPrefs.SetFloat("highScore", highScore);
    }
    else
    {
        highScore = highScoreCheck ?? 0f;
    }
    highScoreText = uiDocument.rootVisualElement.Q<Label>("HighScoreLabel");
    highScoreText.text = "High Score: " + highScore.ToString();

    scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
    restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
    restartButton.style.display = DisplayStyle.None;
    restartButton.clicked += ReloadScene;
    moveForward.Enable();
    lookPosition.Enable();
}

// Update is called once per frame
void Update()
{
    UpdateScore();
    MovePlayer();
}
void UpdateScore()
{
    elapsedTime += Time.deltaTime;
    score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
    scoreText.text = "Score: " + score;
    Debug.Log("Score: " + score + " and High Score: " + highScore);
}
void MovePlayer()
{
    if (moveForward.IsPressed())
    {
        // Calculate mouse direction
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(lookPosition.ReadValue<Vector2>());
        Vector2 direction = (mousePos - transform.position).normalized;

        // Move player in direction of mouse
        transform.up = direction;
        rb.AddForce(direction * thrustForce);
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
    if (moveForward.WasPressedThisFrame())
    {
        boosterFlame.SetActive(true);
    }
    else if (moveForward.WasReleasedThisFrame())
    {
        boosterFlame.SetActive(false);
    } 
}
void OnCollisionEnter2D(Collision2D collision)
{
    Instantiate(explosionEffect, transform.position, transform.rotation);
    restartButton.style.display = DisplayStyle.Flex;
    Destroy(gameObject);
    if (score > highScore)
    {
        highScore = score;
        highScoreText.text = "NEW High Score: " + highScore.ToString() + "!";
        PlayerPrefs.SetFloat("highScore", highScore);
        PlayerPrefs.Save();

        StartHighScoreFlash();
    }
}
void StartHighScoreFlash()
{
    bool bright = false;
    highScoreText.schedule.Execute(() =>
    {
        if (bright)
        {
            highScoreText.style.backgroundColor = new Color(1f, 0.5f, 0f);
            highScoreText.style.scale = new Scale(Vector3.one);
        }
        else
        {
            highScoreText.style.backgroundColor = new Color(1f, 0.85f, 0.25f);
            highScoreText.style.scale = new Scale(new Vector3(1.08f, 1.08f, 1f));
        }
        bright = !bright;
    }).Every(500); // milliseconds
}
void ReloadScene()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
