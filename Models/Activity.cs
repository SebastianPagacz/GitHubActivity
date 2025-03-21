using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubActivity.Models;

public class Activity
{
    public string Id { get; set; } = default!;
    public string Type { get; set; } = default!;
    public Actor Actor { get; set; } = default!;
    public Repo Repo { get; set; } = default!;
    public Payload Payload { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
}
