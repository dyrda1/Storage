using Quartz;
using Quartz.Impl;
using System;

namespace BBL.Ultils
{
    public class MarkScheduler
    {
        public static async void Start()
        {
            var time = Convert.ToDateTime("18:00");

            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<MarksEmployees>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")     
                .StartAt(time)
                .WithCalendarIntervalSchedule(x=>x
                    .SkipDayIfHourDoesNotExist(true)
                    .WithIntervalInDays(1))
                .Build();                               

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
