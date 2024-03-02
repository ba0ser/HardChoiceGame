using Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public QuestionManager questionManager;

    void Start()
    {
        var questionManager = new QuestionManager();
    }
}
