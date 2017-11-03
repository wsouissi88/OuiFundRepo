using OuiFund.Domain.Model;
using OuiFund.Domain.Repositories;
using OuiFund.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questRepository { get; set; }
        public QuestionService(IQuestionRepository questRepo)
        {
            questRepository = questRepo;
        }
        public bool ajouterQuestion(Question question)
        {
            if (question != null)
            {
                questRepository.Create(question);
                return true;
            }
            else { return false; }
        }

        public Question getQuestionById(int idquest)
        {
            return questRepository.GetById(idquest);
        }

        public List<Question> getListQuestions()
        {
            return questRepository.GetAll().ToList();
        }

        public List<Question> getQuestionsByType(TypeQuestion type)
        {
            List<Question> questions = questRepository.GetAll().Where(q => q.TypeQuest == type).ToList();

            return questions;
        }
        public List<Question> RandomQuestions(TypeQuestion type, int count)
        {
            List<Question> listQuestion = new List<Question>();
            Random random = new Random();
            List<Question> questions = getQuestionsByType(type);
            while (listQuestion.Count < count)
            {
                int index = random.Next(questions.Count);
                Question question = questions[index];
                if (!listQuestion.Contains(question))
                {
                    listQuestion.Add(question);
                }
            }
            //for (int i = 0; i < count; i++)
            //{
            //    int index = i + random.Next(questions.Count-i);
            //    Question question = questions[index];
            //    listQuestion.Add(question);
            //}
            return listQuestion;
        }

        public void modifierQuestion(Question question)
        {
            questRepository.Update(question);
        }

        public bool supprimerQuestion(int idQuestion)
        {
            Question quest = questRepository.GetById(idQuestion);

            if (quest != null)
            {
                questRepository.Delete(quest);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
