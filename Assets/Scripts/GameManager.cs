using UnityEngine;
using UnityEngine.SceneManagement;

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

    private float countUpTimer = 0;

    [SerializeField]
    private int countDownTimer;


    private void Awake()
    {
        CreateCheckSingleton();

        player1 = new Players(Player.red);
        player2 = new Players(Player.blue);
    }

    private void Start()
    {
        ballController.StartBallMovement();
    }

    private void Update()
    {
        if (player1.score >= 5)
        {
            GameWon(player1.player);
        }

        if (player2.score >= 5)
        {
            GameWon(player2.player);
        }
    }

    private void FixedUpdate()
    {
        //if (countDownTimer >= 0)
        //{
        //    countUpTimer += Time.fixedDeltaTime;
        //    if (countUpTimer >= 1)
        //    {
        //        timerTextController.SetTimerValue(countDownTimer--);
        //        countUpTimer = 0;
        //    }
        //}

        //if(countDownTimer <= 0)
        //{
        //    countDownTimer = 0;
        //    timerTextController.gameObject.SetActive(false);
        //    ballController.StartBallMovement();
        //}

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

        ballController.StartBallMovement();
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
        Time.timeScale = 1;
        ballController.StartBallMovement();
    }
}

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