using BLL.Ultils;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;

namespace BBL.Ultils
{
    public class MarkScheduler
    {
        public static async void Start(IServiceProvider serviceProvider)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
            await scheduler.Start();

            IJobDetail jobDetail = JobBuilder.Create<MarksEmployees>().Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("MailingTrigger", "default")
                .StartAt(new DateTimeOffset(Convert.ToDateTime("18:00")))
                .WithCalendarIntervalSchedule(x => x
                    .SkipDayIfHourDoesNotExist(true)
                    .WithIntervalInDays(1))
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
