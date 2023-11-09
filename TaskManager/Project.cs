using System;
using System.Collections.Generic;

namespace TaskManager
{
    enum ProjectStatus { Project, Execution, Closed }
    enum TaskStatus { Assigned, InProgress, UnderReview, Completed }
    internal class Project
    {
        private string description;
        private DateTime deadline;
        private string initiator;
        private string teamLead;
        public List<Task> tasks;
        protected ProjectStatus status;
        public List<string> team;

        public Project(string description, DateTime deadline, string initiator, string teamLead, List<string> team)
        {
            this.description = description;
            this.deadline = deadline;
            this.initiator = initiator;
            this.teamLead = teamLead;
            this.tasks = new List<Task>();
            this.status = ProjectStatus.Project;
            this.team = team;
        }

        public void addTask(Task task)
        {
            this.tasks.Add(task);
        }

        public void assignTasks()
        {
            int taskIndex = 0;
            foreach (Task task in tasks)
            {
                string performer = this.team[taskIndex % team.Count];
                task.setPerformer(performer);
                taskIndex++;
            }
        }

        public void transferToExecution()
        {
            this.status = ProjectStatus.Execution;
        }

        public bool isCompleted()
        {
            bool allTasksCompleted = true;
            foreach (Task task in tasks)
            {
                if (task.status != TaskStatus.Completed)
                {
                    allTasksCompleted = false;
                    break;
                }
            }
            return allTasksCompleted;
        }

        public void closeProject()
        {
            if (!isCompleted())
            {
                throw new Exception("Проект нельзя завершить, если не завершены все задачи");
            }
            this.status = ProjectStatus.Closed;
        }
    }
}

