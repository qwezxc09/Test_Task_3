using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskStaffBerry
{
    public delegate void TaskDelegate();
    public class AsyncClass
    {
        private List<TaskDelegate> TasksList { get; set; }
        public AsyncClass()
        {
            TasksList = new List<TaskDelegate>();
        }
        public void AddTask(TaskDelegate task)
        {
            TasksList.Add(task);
        }
        public async Task ExecuteTasksAsync()
        {
            foreach(var a in TasksList)
                await Task.Run(() => a());
        }
    }
}
