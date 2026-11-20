using QuizApi.Models;

namespace QuizApi.Data;

// Saare questions yahan hain. Naya question add karna ho to bas ek line copy-paste karo.
// CorrectIndex 0 se start hota hai: 0 = pehla option, 1 = dusra, 2 = teesra, 3 = chautha.
public static class QuestionBank
{
    public static readonly List<Category> Categories = new()
    {
        new("csharp", "C# and .NET", "Classes, async, EF Core and ASP.NET basics."),
        new("web", "Web Development", "React, CSS, JavaScript, HTTP and Git."),
        new("gk", "General Knowledge", "Geography, science and a bit of India.")
    };

    public static readonly List<Question> Questions = new()
    {
        // ---------- C# and .NET ----------
        new(101, "csharp", "Which keyword stops other classes from inheriting from a class?",
            new[] { "abstract", "sealed", "static", "readonly" }, 1,
            "A sealed class cannot be used as a base class."),
        new(102, "csharp", "Which interface lets you loop over a custom collection with foreach?",
            new[] { "IDisposable", "IEnumerable", "IComparable", "ICloneable" }, 1,
            "foreach works on any type that implements IEnumerable (or has a GetEnumerator method)."),
        new(103, "csharp", "In a modern ASP.NET Core project, which file sets up services and the request pipeline?",
            new[] { "Global.asax", "Program.cs", "Web.config", "Index.cshtml" }, 1,
            "Program.cs is the entry point where builder.Services and the middleware pipeline are configured."),
        new(104, "csharp", "Which status code does return NotFound() send from a Web API controller?",
            new[] { "204", "400", "404", "500" }, 2,
            "NotFound() returns HTTP 404."),
        new(105, "csharp", "Which EF Core method writes your tracked changes to the database?",
            new[] { "Commit()", "SaveChanges()", "Flush()", "Apply()" }, 1,
            "DbContext.SaveChanges() (or SaveChangesAsync()) persists all pending changes."),
        new(106, "csharp", "What is async/await mainly used for in C#?",
            new[] { "Waiting for I/O without blocking the thread", "Making code run faster on one CPU core", "Hiding exceptions", "Creating new classes" }, 0,
            "await frees the thread while slow work such as database or network calls is in progress."),
        new(107, "csharp", "Which of these is a value type in C#?",
            new[] { "string", "int[]", "int", "object" }, 2,
            "int is a value type. string, arrays and object are reference types."),
        new(108, "csharp", "What does JWT stand for?",
            new[] { "Java Web Token", "JSON Web Token", "JavaScript Web Tool", "Joint Web Transfer" }, 1,
            "A JSON Web Token carries signed claims and is commonly used for API authentication."),

        // ---------- Web Development ----------
        new(201, "web", "Which React hook stores state inside a function component?",
            new[] { "useEffect", "useState", "useRef", "useMemo" }, 1,
            "useState returns the current value and a setter function."),
        new(202, "web", "Which CSS property centers flex items along the main axis?",
            new[] { "align-content", "justify-content", "flex-wrap", "order" }, 1,
            "justify-content aligns items along the main axis. align-items handles the cross axis."),
        new(203, "web", "Which HTTP method is normally used to create a new resource?",
            new[] { "GET", "POST", "DELETE", "HEAD" }, 1,
            "POST sends data to the server to create something new."),
        new(204, "web", "What does CORS stand for?",
            new[] { "Cross-Origin Request Security", "Client-Origin Resource Sharing", "Cross-Origin Resource Sharing", "Cross-Object Resource Sharing" }, 2,
            "CORS controls which other origins (websites) are allowed to call your API from a browser."),
        new(205, "web", "Which array method returns a new array with every element transformed?",
            new[] { "forEach", "map", "push", "find" }, 1,
            "map returns a new array. forEach returns nothing."),
        new(206, "web", "Which keyword declares a block-scoped variable that can be reassigned?",
            new[] { "var", "let", "const", "static" }, 1,
            "let is block-scoped and reassignable. const cannot be reassigned."),
        new(207, "web", "Why does React ask for a key prop when you render a list?",
            new[] { "To style each item", "To help React track which items changed", "To make items clickable", "To sort the list" }, 1,
            "Stable keys let React update only the items that actually changed."),
        new(208, "web", "Which Git command uploads your local commits to a remote repository?",
            new[] { "git pull", "git push", "git clone", "git fetch" }, 1,
            "git push sends your commits to the remote, for example GitHub."),

        // ---------- General Knowledge ----------
        new(301, "gk", "What is the capital of Australia?",
            new[] { "Sydney", "Melbourne", "Canberra", "Perth" }, 2,
            "Canberra is the capital. Sydney is the largest city."),
        new(302, "gk", "Which is the largest planet in our solar system?",
            new[] { "Saturn", "Jupiter", "Neptune", "Earth" }, 1,
            "Jupiter is more than twice as massive as all the other planets combined."),
        new(303, "gk", "Who wrote the Indian national anthem, Jana Gana Mana?",
            new[] { "Bankim Chandra Chatterjee", "Rabindranath Tagore", "Sarojini Naidu", "Muhammad Iqbal" }, 1,
            "Rabindranath Tagore wrote it. Bankim Chandra Chatterjee wrote Vande Mataram."),
        new(304, "gk", "What is the chemical symbol for gold?",
            new[] { "Ag", "Au", "Gd", "Go" }, 1,
            "Au comes from the Latin word aurum. Ag is silver."),
        new(305, "gk", "How many states does India have?",
            new[] { "25", "28", "29", "30" }, 1,
            "India has 28 states and 8 union territories."),
        new(306, "gk", "Which gas do plants absorb from the air for photosynthesis?",
            new[] { "Oxygen", "Nitrogen", "Carbon dioxide", "Hydrogen" }, 2,
            "Plants take in carbon dioxide and release oxygen."),
        new(307, "gk", "Which is the largest ocean on Earth?",
            new[] { "Atlantic", "Indian", "Arctic", "Pacific" }, 3,
            "The Pacific Ocean covers about a third of the planet's surface."),
        new(308, "gk", "Who is called the Father of the Nation in India?",
            new[] { "Jawaharlal Nehru", "Mahatma Gandhi", "Sardar Patel", "B. R. Ambedkar" }, 1,
            "Mahatma Gandhi is honoured as the Father of the Nation.")
    };
}
