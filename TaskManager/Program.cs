using System;
using System.Collections.Generic;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> team = new List<string>() { "Алиса", "Боб", "БОБ2", "Давид", "Шелли", "Фрэнк", "Джеки", "Гарри", "Круэлла", "Джек" };
            Project project = new Project("Проект", DateTime.Now.AddDays(7), "Initiator", "Тим Лид", team);

            project.addTask(new Task("Задача 1", DateTime.Now.AddDays(3), "Initiator"));
            project.addTask(new Task("Задача 2", DateTime.Now.AddDays(5), "Initiator"));

            project.assignTasks();

            project.transferToExecution();

            Task task1 = project.tasks[0];
            task1.startWork();

            Task task2 = project.tasks[1];
            task2.delegateTask("Новый исполнитель");

            Report report = new Report("Текст отчета", DateTime.Now, "Исполнитель");
            task1.addReport(report);

            task1.reviewReport(true);

            if (project.isCompleted())
            {
                project.closeProject();
                Console.WriteLine("Проект завершен");
            }
            else
            {
                Console.WriteLine("Проект не завершен");
            }
            Console.ReadKey();
        }
    }
}
