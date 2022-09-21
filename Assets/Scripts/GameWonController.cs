using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameWonController : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textEditable;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button quitButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void EditWonText(Player pType)
    {
        if(pType == Player.red)
        {

            textEditable.text = "Red Player";
            textEditable.color = Color.red;
        }
        if(pType == Player.blue)
        {
            textEditable.text = "Blue Player";
            textEditable.color = Color.blue;
        }
    }

    private void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    private void ReloadLevel()
    {
        GameManager.Instance.ReloadLevel();
        Time.timeScale = 1;
    }
}
