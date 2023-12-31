﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NganHangDe.DataAccess;
using NganHangDe.Models;
using NganHangDe.ModelsDb;
using NganHangDe.ViewModels;
using NganHangDe.Extensions;

namespace NganHangDe.Services
{
    public class QuizService : IQuizService
    {
        public readonly ICategoryService _categoryService;
        public QuizService()
        {
            _categoryService = new CategoryService();
        }
        public async Task<List<QuizModel>> GetAllQuizzesAsync()
        {
            using (var _context = new AppDbContext())
            {
                return await _context.Quizzes
                    .Select(q => new QuizModel { Id = q.Id, Name = q.Name })
                    .ToListAsync();
            }
        }
        public async Task<Quiz> GetFullQuizById(int id)
        {
            using (var _context = new AppDbContext())
            {
                return await _context.Quizzes
                    .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .ThenInclude(q => q.Answers)
                    .SingleOrDefaultAsync(q => q.Id == id);
            }
        }
        public async Task CreateQuizAsync(string name, string description, TimeSpan timeLimit)
        {
            using (var _context = new AppDbContext())
            {
                _context.Quizzes.Add(new Quiz
                {
                    Name = name,
                    Description = description,
                    TimeLimit = timeLimit,
                });
                await _context.SaveChangesAsync();
            }

        }
        public async Task AddSingleQuestionToQuizAsync(int questionId, int quizId)
        {
            using (var _context = new AppDbContext())
            {
                Quiz quiz = await _context.Quizzes
                    .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .SingleOrDefaultAsync(q => q.Id == quizId);
                QuizQuestion quizQuestion = new QuizQuestion
                {
                    QuizId = quizId,
                    QuestionId = questionId
                };
                quiz.QuizQuestions.Add(quizQuestion);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddMultipleQuestionsToQuizAsync(List<int> questionIds, int quizId)
        {
            foreach (var questionId in questionIds)
            {
                await AddSingleQuestionToQuizAsync(questionId, quizId);
            }
        }
        public async Task AddRandomQuestionsToQuizAsync(int amountAdded, List<int> questionIds, int quizId)
        {
            if (amountAdded == 0) return;
            questionIds.Shuffle();
            questionIds = questionIds.Take(amountAdded).ToList();
            await AddMultipleQuestionsToQuizAsync(questionIds, quizId);
        }
        public async Task<List<QuestionModel>> GetAllQuestionsFromQuizAsync(int quizId)
        {
            using (var _context = new AppDbContext())
            {
                Quiz quiz = await _context.Quizzes
                    .Include(q => q.QuizQuestions)
                    .ThenInclude(qq => qq.Question)
                    .ThenInclude(q => q.Answers)
                    .SingleOrDefaultAsync(q => q.Id == quizId);
                return quiz.QuizQuestions.Select(qq => new QuestionModel
                {
                    Id = qq.Question.Id,
                    Name = qq.Question.Name,
                    Text = qq.Question.Text,
                    CategoryId = qq.Question.CategoryId,
                    Answers = qq.Question.Answers.Select(a => new AnswerModel
                    {
                        Id = a.Id,
                        Text = a.Text,
                        Grade = a.Grade,
                    }).ToList(),
                }).ToList();
            }
        }
        public async Task DeleteSingleQuestionFromQuizAsync(int questionId, int quizId)
        {
            using (var _context = new AppDbContext())
            {
                Quiz quiz = await _context.Quizzes
                    .Include(q => q.QuizQuestions)
                    .SingleOrDefaultAsync(q => q.Id == quizId);
                QuizQuestion quizQuestion = quiz.QuizQuestions
                    .SingleOrDefault(qq => qq.QuestionId == questionId);
                quiz.QuizQuestions.Remove(quizQuestion);
                await _context.SaveChangesAsync();
            }

        }
    }

}
