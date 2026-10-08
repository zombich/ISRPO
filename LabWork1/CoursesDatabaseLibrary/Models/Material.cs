using System;
using System.Collections.Generic;

namespace CoursesDatabaseLibrary.Models;

public partial class Material
{
    public int Id { get; set; }

    public int? TopicId { get; set; }

    public string Title { get; set; } = null!;

    public int? MaterialTypeId { get; set; }

    public string? Content { get; set; }

    public virtual MaterialType? MaterialType { get; set; }

    public virtual Topic? Topic { get; set; }
}
