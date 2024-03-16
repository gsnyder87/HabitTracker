using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Domain;
public class User
{
    public int UserId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string EmailAddress { get; set; }
}
