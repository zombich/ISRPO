using System;
using System.Collections.Generic;

namespace CoursesDatabaseLibrary.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public int? TopicId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Topic? Topic { get; set; }
}
