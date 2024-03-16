using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Domain;
public class Activity
{
    public int ActivityId { get; set; }
    public Habit Habit { get; set; }
    public int HabitId { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public DateTime ActivityDate { get; set; }
}
