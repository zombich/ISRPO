using System;
using System.Collections.Generic;

namespace CoursesDatabaseLibrary.Models;

public partial class Test
{
    public int Id { get; set; }

    public int? TopicId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Topic? Topic { get; set; }
}
