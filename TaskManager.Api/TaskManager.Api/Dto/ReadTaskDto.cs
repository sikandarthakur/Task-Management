using System;

namespace TaskManager.Api.Dto
{
    public class ReadTaskDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOpen { get; set; }
        public string Status { get; set; }
    }
}
