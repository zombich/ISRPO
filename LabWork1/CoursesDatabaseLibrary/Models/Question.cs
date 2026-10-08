using System;
using System.Collections.Generic;

namespace CoursesDatabaseLibrary.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? TestId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int? QuestionTypeId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual QuestionType? QuestionType { get; set; }

    public virtual Test? Test { get; set; }
}
