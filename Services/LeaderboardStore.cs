using QuizApi.Models;

namespace QuizApi.Services;

public class LeaderboardStore
{
    private readonly List<LeaderboardEntry> _entries = new();
    private readonly object _lock = new();

    // Entry add karta hai aur us category mein rank return karta hai
    public int Add(LeaderboardEntry entry)
    {
        lock (_lock)
        {
            _entries.Add(entry);
            return _entries
                .Where(e => e.CategoryId == entry.CategoryId)
                .OrderByDescending(e => e.Score)
                .ThenBy(e => e.TimeTakenSeconds)
                .ThenBy(e => e.PlayedAt)
                .ToList()
                .IndexOf(entry) + 1;
        }
    }

    public List<LeaderboardEntry> Top(string? categoryId, int take = 10)
    {
        lock (_lock)
        {
            return _entries
                .Where(e => string.IsNullOrEmpty(categoryId) || e.CategoryId == categoryId)
                .OrderByDescending(e => e.Total == 0 ? 0 : (double)e.Score / e.Total)
                .ThenBy(e => e.TimeTakenSeconds)
                .Take(take)
                .ToList();
        }
    }
}
