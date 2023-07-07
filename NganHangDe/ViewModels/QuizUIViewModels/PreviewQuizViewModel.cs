﻿using Microsoft.Identity.Client;
using NganHangDe.Commands;
using NganHangDe.Models;
using NganHangDe.ModelsDb;
using NganHangDe.Services;
using NganHangDe.Stores;
using NganHangDe.ViewModels.StartupViewModels;
using NganHangDe.ViewModels.TabbedNavigationTabViewModels;
using NganHangDe.Views.QuizUIViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace NganHangDe.ViewModels.QuizUIViewModels
{
    public class PreviewQuizViewModel : ViewModelBase
    {
        private readonly NavigationStore _ancestorNavigationStore;
        private int _quizId;
        private QuizService _quizService;
        private int _questionNumber = 1;

        //private ObservableCollection<QuestionModel> _questionList = new ObservableCollection<QuestionModel>();
        //public ObservableCollection<QuestionModel> QuestionList => _questionList;
        private ObservableCollection<QuestionModel> _loadedQuestionList = new ObservableCollection<QuestionModel>();
        
        public ObservableCollection<QuestionModel> LoadedQuestionList => _loadedQuestionList;
        //private ObservableCollection<AnswerModel> _selectedCorrectAnswers;
        //public ObservableCollection<AnswerModel> SelectedCorrectAnswers
        //{
        //    get { return _selectedCorrectAnswers; }
        //    set
        //    {
        //        _selectedCorrectAnswers = value;
        //        OnPropertyChanged(nameof(SelectedCorrectAnswers));
        //    }
        //}
        private ObservableCollection<QuestionModel> _shuffledQuestionList;
        
        public RelayCommand ScrollToItemCommand { get; set; }
        //public ICommand ScrollToItemCommand { get; set; }
        public TimeSpan QuizSpan { get; set; }
        private string _displayTime;
        public string DisplayTime
        {
            get { return _displayTime; }
            set
            {
                if (_displayTime != value)
                {
                    _displayTime = value;
                    OnPropertyChanged(nameof(DisplayTime));
                }
            }
        }
        private bool _isPopupVisible;
        public bool IsPopupVisible
        {
            get { return _isPopupVisible; }
            set
            {
                _isPopupVisible = value;
                OnPropertyChanged(nameof(IsPopupVisible));
            }
        }

        public ObservableCollection<QuestionModel> ShuffledQuestionList
        {
            get { return _shuffledQuestionList; }
            set
            {
                _shuffledQuestionList = value;
                OnPropertyChanged(nameof(ShuffledQuestionList));             
            }
        }
        private bool _isShuffleChecked;
        public bool IsShuffleChecked
        {
            get { return _isShuffleChecked; }
            set
            {
                _isShuffleChecked = value;
                OnPropertyChanged(nameof(IsShuffleChecked));
            }
        }
        private int _selectedAnswerScore;
        public int SelectedAnswerScore
        {
            get { return _selectedAnswerScore; }
            set
            {
                _selectedAnswerScore = value;
                OnPropertyChanged(nameof(SelectedAnswerScore));
            }
        }
        private double _totalGrade;
        public double TotalGrade
        {
            get { return _totalGrade; }
            set
            {
                _totalGrade = value;
                OnPropertyChanged(nameof(TotalGrade));
            }
        }
        private bool _isFinishAttemptClicked;
        public bool IsFinishAttemptClicked
        {
            get { return _isFinishAttemptClicked; }
            set
            {
                _isFinishAttemptClicked = value;
                OnPropertyChanged(nameof(IsFinishAttemptClicked));
            }
        }
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime finishTime;
        public DateTime FinishTime
        {
            get { return finishTime; }
            set
            {
                finishTime = value;
                OnPropertyChanged(nameof(FinishTime));
            }
        }
        public TimeSpan TimeTaken => FinishTime - StartTime;
        private double _totalAnswerGrade;
        public double TotalAnswerGrade
        {
            get { return _totalAnswerGrade; }
            set
            {
                _totalAnswerGrade = value;
                OnPropertyChanged(nameof(TotalAnswerGrade));
            }
        }
        private double _scoreOutOfTen;
        public double ScoreOutOfTen
        {
            get { return _scoreOutOfTen; }
            set
            {
                _scoreOutOfTen = value;
                OnPropertyChanged(nameof(ScoreOutOfTen));
            }
        }
        private double _percentage;
        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
        private ObservableCollection<AnswerModel> _correctAnswers;

        public ObservableCollection<AnswerModel> CorrectAnswers
        {
            get { return _correctAnswers; }
            set
            {
                _correctAnswers = value;
                OnPropertyChanged(nameof(CorrectAnswers));
            }
        }
        public RelayCommand FinishAttemptCommand { get; set; }
        public RelayCommand ShowPopupCommand { get; private set; }
        public RelayCommand HidePopupCommand { get; private set; }
        public ICommand ToQuizzesViewCommand { get; set; }
        public PreviewQuizViewModel(NavigationStore ancestorNavigationStore, int quizId, bool isShuffleChecked, ObservableCollection<QuestionModel> shuffledQuestionList)
        {
            
            _isShuffleChecked = isShuffleChecked;
            _shuffledQuestionList = shuffledQuestionList;
            _ancestorNavigationStore = ancestorNavigationStore;
            _quizId = quizId;
            ShowPopupCommand = new RelayCommand(ExecuteShowPopupCommand);
            HidePopupCommand = new RelayCommand(ExecuteHidePopupCommand);
            FinishAttemptCommand = new RelayCommand(FinishAttempt);
            _quizService = new QuizService();
            _ = LoadQuestionsAsync();
            ToQuizzesViewCommand = new NavigateCommand<AllQuizzesViewModel>(ancestorNavigationStore, typeof(AllQuizzesViewModel));
            //ScrollToItemCommand = new ScrollToItemCommand(LoadedQuestionList, QuestionItemsControl, QuestionScrollViewer);
            ScrollToItemCommand = new RelayCommand(ExecuteScrollToItemCommand);
        }
        private DispatcherTimer _timer;

        private void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); // Set the interval duration (1 second in this example)
            _timer.Tick += Timer_Tick; // Attach the event handler
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            
            QuizSpan = QuizSpan.Subtract(TimeSpan.FromSeconds(1));
            DisplayTime = QuizSpan.ToString();
            if (QuizSpan <= TimeSpan.Zero)
            {
                
                _timer.Stop();
                IsFinishAttemptClicked = true;
                OnPropertyChanged(nameof(IsFinishAttemptClicked));
                FinishAttemptCommand.Execute(this); 
            }
        }

        private async Task LoadQuestionsAsync()
        {
            StartTime = DateTime.Now;
            if (_isShuffleChecked == false)
            {
                try
                {
                    var quiz = await _quizService.GetFullQuizById(_quizId);
                    QuizSpan = quiz.TimeLimit;
                    StartTimer();
                    var questions = await _quizService.GetAllQuestionsFromQuizAsync(_quizId);
                    foreach (var question in questions)
                    {

                        var questionModel = new QuestionModel
                        {
                            Id = question.Id,
                            Text = question.Text,
                            Answers = question.Answers,
                            
                        };
                        var loadQuestionCommand = new LoadSingleQuestionCommand(LoadQuestionCallback);
                        
                        await loadQuestionCommand.ExecuteAsync(questionModel.Id);
                        
                    }
       
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
            }
            else
            {
                SetShuffledQuestionList(_shuffledQuestionList);
            }
        }
        private void LoadQuestionCallback(QuestionModel question, List<AnswerModel> answers)
        {
            
            question.Answers = answers;
            //foreach (var answer in answers)
            //{
            //    var answerModel = new AnswerModel
            //    {
            //        Id = answer.Id,
            //        Grade = answer.Grade,
            //        AnswerGroup = question.Id
            //    };
            //}
            //Console.WriteLine(question.IsMultipleAnswers);
            _loadedQuestionList.Add(question);
            question.QuestionNumber = _questionNumber++;
            var correctAnswers = new ObservableCollection<AnswerModel>(answers.Where(answer => answer.Grade > 0));
            question.CorrectAnswers = correctAnswers;
            //Console.WriteLine("PreviewQuizShuffle = " + IsShuffleChecked);
        }
        public void SetShuffledQuestionList(ObservableCollection<QuestionModel> shuffledQuestionList)
        {

            ShuffledQuestionList = shuffledQuestionList;
            foreach (var question in shuffledQuestionList)
            {
                if (!_loadedQuestionList.Any(q => q.Id == question.Id))
                {
                    _loadedQuestionList.Add(question);
                }
                
            }
        }
        public void SetIsShuffleChecked(bool isShuffleChecked)
        {
            IsShuffleChecked = isShuffleChecked;
        }
        private void ExecuteShowPopupCommand(object parameter)
        {
            IsPopupVisible = true;
        }
        private void ExecuteHidePopupCommand(object parameter)
        {
            IsPopupVisible = false;
        }
        public void FinishAttempt(object parameter)
        {
            IsPopupVisible = false;
            FinishTime = DateTime.Now;
            // Tính toán các câu trả lời đúng
            double totalGrade = 0;
            double totalAnswerGrade = 0; //tổng điểm của quiz 
            foreach (var question in LoadedQuestionList)
            {
                var selectedCorrectAnswers = question.Answers.Where(answer => answer.Grade > 0 && answer.IsSelected);

                question.SelectedCorrectAnswers = new ObservableCollection<AnswerModel>(selectedCorrectAnswers);
                double questionSelectedGrade = CalculateQuestionGrade(question);
                double questionGrade = CalculateAnswerGrade(question);
                totalGrade += questionSelectedGrade;
                totalAnswerGrade += questionGrade;
            }
            //Console.WriteLine(totalGrade);
            TotalGrade = totalGrade;
            TotalAnswerGrade = totalAnswerGrade;
            ScoreOutOfTen = Math.Round((totalGrade / totalAnswerGrade)*10,2);
            Percentage = Math.Round((totalGrade/totalAnswerGrade)*100,2);
            IsFinishAttemptClicked = true;
        }
        private double CalculateQuestionGrade(QuestionModel question)
        {
            double totalGrade = 0;
            
            foreach (var answer in question.Answers)
            {
                if (answer.IsSelected)
                {
                    totalGrade += answer.Grade;
                }
            }
            return totalGrade;
        }
        private double CalculateAnswerGrade(QuestionModel question)
        {
            double totalAnswersGrade = 0;
            foreach(var answer in question.Answers)
            {
                totalAnswersGrade += answer.Grade;
            }
            return totalAnswersGrade;
        }
        private double _questionListVerticalOffset;

        public double QuestionListVerticalOffset
        {
            get { return _questionListVerticalOffset; }
            set { _questionListVerticalOffset = value;
                OnPropertyChanged(nameof(QuestionListVerticalOffset));
            }
        }

        private void ExecuteScrollToItemCommand(object parameter)

        {
            Button button = (Button) parameter;
            int questionNumber = (int)button.Content;
            ItemsControl questionItemsControl = (ItemsControl)button.Tag;
            QuestionModel item = LoadedQuestionList.Single(x => x.QuestionNumber == questionNumber);
            var index = LoadedQuestionList.IndexOf(item);
            if (index >= 0)
            {
                FrameworkElement itemContainer = (FrameworkElement)questionItemsControl.ItemContainerGenerator.ContainerFromItem(item);
                ScrollViewer scrollViewer = FindVisualParent<ScrollViewer>(itemContainer);
                FrameworkElement scrollViewerContent = (FrameworkElement)scrollViewer.Content;
                GeneralTransform transform = itemContainer.TransformToAncestor(scrollViewerContent);
                Point itemOffset = transform.Transform(new Point(0, 0));
                scrollViewer.ScrollToVerticalOffset(itemOffset.Y);
            }
        }
        public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            return parent ?? FindVisualParent<T>(parentObject);
        }

    }
}

