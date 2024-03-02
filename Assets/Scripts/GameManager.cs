using System;
using System.Collections;
using Managers;
using Timer;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] public ChoiceWindow _choiceWindow;
    [SerializeField] public TimeTickerController _timeTickerController;
    
    private QuestionManager _questionManager;

    private int _timer;

    private void Awake()
    {
        _questionManager = new QuestionManager();
        _questionManager.Initialize();

        _timer = -1;
    }

    private void Start()
    {
        _timeTickerController.SecondPassedEvent += HandleSecondPassed;

        StartGame();
    }

    private void HandleSecondPassed(object sender, EventArgs e)
    {
        if (_timer < 0)
        {
            return;
        }

        _timer -= 1;

        if (_timer > 0)
        {
            _choiceWindow.UpdateTimer(_timer);
        }
        if (_timer <= 0)
        {
            _choiceWindow.StopTimer();
            _choiceWindow.ShowChoicePercents();
            SetNextQuestion();
        }
    }

    private void StartGame()
    {
        StartNewQuest();
    }

    private void StartNewQuest()
    {
        var randomPercent = Random.Range(_questionManager.QuestionsConfig.RandomRangeMin, _questionManager.QuestionsConfig.RandomRangeMax);

        _choiceWindow.SetQuestion(_questionManager.GetQuestion(), randomPercent);

        _timer = _questionManager.QuestionsConfig.RoundTimer;
        _choiceWindow.StartTimer(_timer);
    }

    private void SetNextQuestion()
    {
        StartCoroutine(StartQuestion());
    }

    private IEnumerator StartQuestion()
    {
        yield return new WaitForSeconds(_questionManager.QuestionsConfig.StartRoundDelay);
        StartNewQuest();
    }
}
