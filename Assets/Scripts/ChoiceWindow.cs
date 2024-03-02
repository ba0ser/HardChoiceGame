using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer = default;
    [SerializeField] private GameObject _orLable = default;

    [Header("Blue Answer")] [SerializeField]
    private Image _blueAnswerImage = default;

    [SerializeField] private TextMeshProUGUI _blueAnswerDescription = default;
    [SerializeField] private TextMeshProUGUI _blueAnswerChoices = default;

    [Header("Red Answer")] [SerializeField]
    Image _redAnswerImage = default;

    [SerializeField] private TextMeshProUGUI _redAnswerDescription = default;
    [SerializeField] private TextMeshProUGUI _redAnswerChoices = default;

    public void SetQuestion(QuestionModel model, int blueAnswerChoiceProcent)
    {
        _orLable.SetActive(true);

        SetBlueAnswer(model);
        SetRedAnswer(model);

        HideChoicePercents();

        _blueAnswerChoices.text = $"{blueAnswerChoiceProcent}%";
        _redAnswerChoices.text = $"{100 - blueAnswerChoiceProcent}%";
    }

    public void StartTimer(int seconds)
    {
        UpdateTimer(seconds);

        _timer.gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        _timer.gameObject.SetActive(false);
    }

    public void UpdateTimer(int seconds)
    {
        _timer.text = seconds.ToString();
    }

    public void ShowChoicePercents()
    {
        _blueAnswerChoices.gameObject.SetActive(true);
        _redAnswerChoices.gameObject.SetActive(true);
    }
    public void HideChoicePercents()
    {
        _blueAnswerChoices.gameObject.SetActive(false);
        _redAnswerChoices.gameObject.SetActive(false);
    }

    private void SetBlueAnswer(QuestionModel model)
    {
        _blueAnswerDescription.text = model.BlueQuestionText;
        _blueAnswerImage.sprite = model.BlueQuestionSprite;

        _blueAnswerDescription.gameObject.SetActive(true);
        _blueAnswerImage.gameObject.SetActive(true);
    }

    private void SetRedAnswer(QuestionModel model)
    {
        _redAnswerDescription.text = model.RedQuestionText;
        _redAnswerImage.sprite = model.RedQuestionSprite;

        _redAnswerDescription.gameObject.SetActive(true);
        _redAnswerImage.gameObject.SetActive(true);
    }
}
