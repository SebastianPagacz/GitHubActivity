using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubActivity.Models;

public class Actor
{
    public int Id { get; set; }
    public string Login { get; set; } = default!;
    public string DisplayLogin { get; set; } = default!;
    public string Url { get; set; } = default!;
}
