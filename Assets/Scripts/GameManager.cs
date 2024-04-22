using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    [SerializeField] private TextMeshProUGUI rightAnsweredText;

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
        rightAnsweredText.text = "Trả lời đúng: " + rightAnswered;
    }
    public void SetNewQuestion()
    {
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
    }

    public void Answer(int answerNum)
    {
        questionUI.SetActive(false);
        if (answerNum == currentAnswer)
        {
            PlayerController.Instance.anim.SetTrigger("Victory");
        }
        else
            PlayerController.Instance.anim.SetTrigger("Fail");
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
        PlayerController.Instance.GoOn();
        if (GameManager.Instance.rightAnswered < 10)
            GameManager.Instance.rightAnswered++;
    }
    public void GoBackAndSubtractAnsweredNum()
    {
        wrongAnswerUI.SetActive(false);
        if (rightAnswered > 0)
            PlayerController.Instance.GoBack();
        else
            SetNewQuestion();
        if (GameManager.Instance.rightAnswered > 0)
            GameManager.Instance.rightAnswered--;
    }
}
