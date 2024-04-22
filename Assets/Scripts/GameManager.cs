using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private Transform wayPointsObj;
    public List<Transform> wayPoints;

    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private GameObject questionUI;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI aAnswerText;
    [SerializeField] private TextMeshProUGUI bAnswerText;
    [SerializeField] private TextMeshProUGUI cAnswerText;
    [SerializeField] private TextMeshProUGUI dAnswerText;

    [SerializeField] private GameObject rightAnswerUI;
    [SerializeField] private GameObject wrongAnswerUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TextMeshProUGUI currentLevelText;

    public List<int> remainingQuestion;
    public int currentQuestion; 
    public int currentAnswer;
    public int rightAnswered = 0;
    private void Reset()
    {
        LoadWayPoints();
    }
    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        LoadWayPoints();
    }
    private void Start()
    {      
        for(int i=0; i<QuestionManager.Instance.questions.Count; i++)
        {
            remainingQuestion.Add(i);
        }
    }
    private void LoadWayPoints()
    {
        wayPointsObj = transform.Find("Waypoints");
        foreach (Transform point in wayPointsObj)
        {
            wayPoints.Add(point);
        }
    }

    void Update()
    {
        currentLevelText.text = "Level hiện tại: " + PlayerController.Instance.currentPoint;
    }
    public void SetNewQuestion()
    {
        AudioManager.instance.PlayBGM(1);
        questionUI.SetActive(true);
        int rdQues = Random.Range(0, remainingQuestion.Count);
        questionText.text = QuestionManager.Instance.questions[remainingQuestion[rdQues]];
        currentQuestion = remainingQuestion[rdQues];
        remainingQuestion.RemoveAt(rdQues);

        SetRandomAnswer();
    }

    public void SetRandomAnswer()
    {
        currentAnswer = Random.Range(1, 5);
        string[] _answers = QuestionManager.Instance.answers[currentQuestion].Split('/');
        switch (currentAnswer)
        {
            case 1:
                aAnswerText.text = _answers[0];
                bAnswerText.text = _answers[1];
                cAnswerText.text = _answers[2];
                dAnswerText.text = _answers[3];
                break;
            case 2:
                bAnswerText.text = _answers[0];
                aAnswerText.text = _answers[1];
                cAnswerText.text = _answers[2];
                dAnswerText.text = _answers[3];
                break;
            case 3:
                cAnswerText.text = _answers[0];
                aAnswerText.text = _answers[1];
                bAnswerText.text = _answers[2];
                dAnswerText.text = _answers[3];
                break;
            case 4:
                dAnswerText.text = _answers[0];
                aAnswerText.text = _answers[1];
                bAnswerText.text = _answers[2];
                cAnswerText.text = _answers[3];
                break;
        }
    }

    public void StartGame()
    {
        tutorialUI.SetActive(false);
        PlayerController.Instance.GoOn();
        AudioManager.instance.StopAllBGM();
    }

    public void Answer(int answerNum)
    {
        AudioManager.instance.StopAllBGM();
        questionUI.SetActive(false);
        if (answerNum == currentAnswer)
        {
            PlayerController.Instance.anim.SetTrigger("Victory");
            AudioManager.instance.PlaySFX(0);
        }
        else
        {
            AudioManager.instance.PlaySFX(1);
            PlayerController.Instance.anim.SetTrigger("Fail");
        }
    }
    public void SetActiveRightAnswerUI()
    {
        rightAnswerUI.SetActive(true);
    }
    public void SetActiveWrongAnswerUI()
    {
        wrongAnswerUI.SetActive(true);
    }
    public void GoOnAndPlusAnsweredNum()
    {
        rightAnswerUI.SetActive(false);
        if(PlayerController.Instance.currentPoint == 10)
        {
            SetWinGame();
            return;
        }
        PlayerController.Instance.GoOn();
        if (GameManager.Instance.rightAnswered < 10)
            GameManager.Instance.rightAnswered++;
    }
    public void GoBackAndSubtractAnsweredNum()
    {
        wrongAnswerUI.SetActive(false);
        if(remainingQuestion.Count==0)
        {
            SetEndGame();
            return;
        }
        if (PlayerController.Instance.currentPoint > 0)
            PlayerController.Instance.GoBack();
        else
            SetNewQuestion();
        if (GameManager.Instance.rightAnswered > 0)
            GameManager.Instance.rightAnswered--;
    }
    public void SetWinGame()
    {
        winUI.SetActive(true);
    }
    public void SetEndGame()
    {
        loseUI.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
