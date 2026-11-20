namespace QuizApi.Models;

// ---- Internal models (sahi answer yahan hota hai, client ko kabhi nahi bhejte) ----
public record Category(string Id, string Name, string Description);

public record Question(
    int Id,
    string CategoryId,
    string Text,
    string[] Options,
    int CorrectIndex,
    string Explanation);

// ---- DTOs (jo React ko bhejte ya React se lete hain) ----
public record CategoryDto(string Id, string Name, string Description, int QuestionCount);

public record QuestionDto(int Id, string Text, string[] Options);

public record AnswerDto(int QuestionId, int? SelectedIndex);

public record SubmitRequest(
    string PlayerName,
    string CategoryId,
    List<AnswerDto> Answers,
    int TimeTakenSeconds);

public record ReviewItem(
    int QuestionId,
    string Text,
    string[] Options,
    int? SelectedIndex,
    int CorrectIndex,
    bool IsCorrect,
    string Explanation);

public record QuizResult(
    string PlayerName,
    string CategoryId,
    string CategoryName,
    int Score,
    int Total,
    int Percentage,
    int TimeTakenSeconds,
    int Rank,
    List<ReviewItem> Review);

public record LeaderboardEntry(
    string PlayerName,
    string CategoryId,
    string CategoryName,
    int Score,
    int Total,
    int TimeTakenSeconds,
    DateTime PlayedAt);
