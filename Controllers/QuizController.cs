using Microsoft.AspNetCore.Mvc;
using QuizApi.Data;
using QuizApi.Models;
using QuizApi.Services;

namespace QuizApi.Controllers;

[ApiController]
[Route("api/quiz")]
public class QuizController : ControllerBase
{
    private readonly LeaderboardStore _leaderboard;

    public QuizController(LeaderboardStore leaderboard)
    {
        _leaderboard = leaderboard;
    }

    // GET api/quiz/categories
    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var result = QuestionBank.Categories.Select(c => new CategoryDto(
            c.Id,
            c.Name,
            c.Description,
            QuestionBank.Questions.Count(q => q.CategoryId == c.Id)));

        return Ok(result);
    }

    // GET api/quiz/{categoryId}/questions  (sahi answer nahi bhejta)
    [HttpGet("{categoryId}/questions")]
    public IActionResult GetQuestions(string categoryId)
    {
        var questions = QuestionBank.Questions
            .Where(q => q.CategoryId == categoryId)
            .OrderBy(_ => Random.Shared.Next())
            .Select(q => new QuestionDto(q.Id, q.Text, q.Options))
            .ToList();

        if (questions.Count == 0)
            return NotFound(new { message = "Quiz category not found." });

        return Ok(questions);
    }

    // POST api/quiz/submit  (score server pe calculate hota hai)
    [HttpPost("submit")]
    public IActionResult Submit([FromBody] SubmitRequest request)
    {
        var name = (request.PlayerName ?? "").Trim();
        if (name.Length == 0 || name.Length > 20)
            return BadRequest(new { message = "Name must be 1 to 20 characters." });

        var category = QuestionBank.Categories.FirstOrDefault(c => c.Id == request.CategoryId);
        if (category is null)
            return BadRequest(new { message = "Quiz category not found." });

        var categoryQuestions = QuestionBank.Questions
            .Where(q => q.CategoryId == category.Id)
            .ToList();

        var givenAnswers = (request.Answers ?? new List<AnswerDto>())
            .GroupBy(a => a.QuestionId)
            .ToDictionary(g => g.Key, g => g.First().SelectedIndex);

        var review = new List<ReviewItem>();
        foreach (var q in categoryQuestions)
        {
            givenAnswers.TryGetValue(q.Id, out var selected);
            var isCorrect = selected.HasValue && selected.Value == q.CorrectIndex;
            review.Add(new ReviewItem(q.Id, q.Text, q.Options, selected, q.CorrectIndex, isCorrect, q.Explanation));
        }

        var score = review.Count(r => r.IsCorrect);
        var total = review.Count;
        var time = Math.Clamp(request.TimeTakenSeconds, 0, 3600);

        var rank = _leaderboard.Add(new LeaderboardEntry(
            name, category.Id, category.Name, score, total, time, DateTime.UtcNow));

        var result = new QuizResult(
            name, category.Id, category.Name, score, total,
            total == 0 ? 0 : (int)Math.Round(score * 100.0 / total),
            time, rank, review);

        return Ok(result);
    }

    // GET api/quiz/leaderboard?categoryId=csharp
    [HttpGet("leaderboard")]
    public IActionResult GetLeaderboard([FromQuery] string? categoryId)
    {
        return Ok(_leaderboard.Top(categoryId));
    }
}
