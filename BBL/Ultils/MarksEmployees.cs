using DAL;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BBL.Ultils
{
    public class MarksEmployees : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public MarksEmployees(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            if (!(DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.DayOfWeek == DayOfWeek.Saturday))
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetService<ApplicationContext>();

                    var absents = _context.SkippeddDays.Where(x => x.MarkedToday == false).ToList();
                    absents.ForEach(x => ++x.Amount);
                    _context.SkippeddDays.ToList().ForEach(x => x.MarkedToday = false);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
