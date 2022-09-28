using UnityEngine;
using UnityEngine.SceneManagement;
public class Players
{
    public Player player;
    public int score;

    public Players(Player player)
    {
        this.player = player;
        this.score = 0;
    }
}

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private Players player1;
    private Players player2;

    [SerializeField]
    private BallController ballController;

    [SerializeField]
    private GameWonController gameWonController;

    [SerializeField]
    private ScoreController scoreController;

    [SerializeField]
    private TimerTextController timerTextController;

    [SerializeField]
    private float countDownTimer = 3;
    [SerializeField]
    private int topScore;
    private bool isTimerRunning;

    private void Awake()
    {
        CreateCheckSingleton();
        
        player1 = new Players(Player.red);
        player2 = new Players(Player.blue);

        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    private void Start()
    {
        isTimerRunning = true;
        countDownTimer = 3;
    }

    private void Update()
    {
        if (player1.score >= topScore)
        {
            GameWon(player1.player);
        }

        if (player2.score >= topScore)
        {
            GameWon(player2.player);
        }
    }

    private void FixedUpdate()
    {
        if (isTimerRunning)
        {
            if (countDownTimer > 0)
            {
                countDownTimer -= Time.fixedDeltaTime;
                timerTextController.DisplayTime(countDownTimer);
            }
            else
            {
                countDownTimer = 0;
                isTimerRunning = false;
                ballController.StartBallMovement();
            }
        }
    }

    private void CreateCheckSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementScore(Player pType)
    {
        if (pType == Player.red)
        {
            player1.score++;
            scoreController.IncrementScore();
        }

        if (pType == Player.blue)
        {
            player2.score++;
        }

        ballController.ResetBallPosition();

        countDownTimer = 3;
        isTimerRunning = true;
        //ballController.StartBallMovement();
    }

    public int TrackScore(Player pType)
    {
        if (pType == Player.red)
        {
            return player1.score;
        }
        else
        {
            return player2.score;
        }
    }

    public void GameWon(Player pType)
    {
        gameWonController.EditWonText(pType);
        gameWonController.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}