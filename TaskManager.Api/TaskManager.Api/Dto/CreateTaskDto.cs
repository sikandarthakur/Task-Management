using System;

namespace TaskManager.Api.Dto
{
    public class CreateTaskDto
    {
        public int UserId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
