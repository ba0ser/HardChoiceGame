using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "QuestionsConfig", menuName = "QuestionsConfig", order = 1)]
    public class QuestionsConfig : ScriptableObject
    {
        public List<QuestionModel> Questions;
        
        public QuestionModel GetQuestion(int index)
        {
            return Questions[index];
        }
    }
}