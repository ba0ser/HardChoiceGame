using System.Collections.Generic;
using Configs;
using Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class QuestionManager
    {
        public QuestionsConfig QuestionsConfig => _questionsConfig;

        private QuestionsConfig _questionsConfig;
        private List<QuestionModel> _questionPool;

        public void Initialize()
        {
            _questionsConfig = Resources.Load<QuestionsConfig>("QuestionsConfig");

            _questionPool = new List<QuestionModel>();

            LoadQuestionPool();
        }

        private void LoadQuestionPool()
        {
            _questionPool.Clear();
            foreach (var question in _questionsConfig.Questions)
            {
                _questionPool.Add(question);
            }
        }

        public QuestionModel GetQuestion()
        {
            if (_questionPool.Count > 0)
            {
                var qIndex = Random.Range(0, _questionPool.Count);
                return QuestionsConfig.GetQuestion(qIndex);
            }

            return null;
        }

        public void Reload()
        {
            LoadQuestionPool();
        }
    }
}