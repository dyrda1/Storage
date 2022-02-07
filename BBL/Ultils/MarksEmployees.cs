using DAL;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Ultils
{
    public class MarksEmployees : IJob
    {
        private readonly ApplicationContext _context;

        public MarksEmployees(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if (!(DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.DayOfWeek == DayOfWeek.Saturday))
            {
                var absents = _context.SkippeddDays.Where(x => x.MarkedToday == true).ToList();

                absents.ForEach(x => x.Amount++);

                foreach (var skippedDays in _context.SkippeddDays)
                {
                    skippedDays.MarkedToday = false;
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
