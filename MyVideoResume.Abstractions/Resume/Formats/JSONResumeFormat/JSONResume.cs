using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyVideoResume.Abstractions.Resume.Formats.JSONResumeFormat;

public class JSONResume
{
    [JsonIgnore]
    public string? Id { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }

    public Basics Basics { get; set; }
    public List<Work> Work { get; set; }
    public List<Volunteer> Volunteer { get; set; }
    public List<Education> Education { get; set; }
    public List<Award> Awards { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<Publication> Publications { get; set; }
    public List<Skill> Skills { get; set; }
    public List<LanguageItem> Languages { get; set; }
    public List<Interest> Interests { get; set; }
    public List<ReferenceItem> References { get; set; }
    public List<Project> Projects { get; set; }
}

public class Basics
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public Location? Location { get; set; }
}

public class Location
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
}

public class Work
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Summary { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public List<string> Highlights { get; set; }
    [JsonIgnore]
    public string HighlightsFlattened
    {
        get => String.Join(Environment.NewLine, Highlights);
        set
        {
            Highlights.Clear();
            string[] val;
            if (value.Contains("\n"))
                val = value.Split("\n");
            else
                val = value.Split(Environment.NewLine);
            Highlights.AddRange(val);
        }
    }
    public string Url { get; set; }
}

public class Volunteer
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Organization { get; set; }
    public string Position { get; set; }
    public string Summary { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public List<string> Highlights { get; set; }
    public string Url { get; set; }
}

public class Education
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Institution { get; set; }
    public string Area { get; set; }
    public string StudyType { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Score { get; set; }
    public List<string> Courses { get; set; }
    public string Url { get; set; }
}

public class Award
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Title { get; set; }
    public string Date { get; set; }
    public string Awarder { get; set; }
    public string Summary { get; set; }
}

public class Certificate
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public string Issuer { get; set; }
    public string Url { get; set; }
}

public class Publication
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string ReleaseDate { get; set; }
    public string Url { get; set; }
    public string Summary { get; set; }
}

public class Skill
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string Level { get; set; }
    public List<string> Keywords { get; set; }
}

public class LanguageItem
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Language { get; set; }
    public string Fluency { get; set; }
}

public class Interest
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public List<string> Keywords { get; set; }
}

public class ReferenceItem
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
}

public class Project
{
    [JsonIgnore]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public string Name { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Description { get; set; }
    public List<string> Highlights { get; set; }
    public string Url { get; set; }
}