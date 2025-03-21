using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubActivity.Models;

public class Repo
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;

}
