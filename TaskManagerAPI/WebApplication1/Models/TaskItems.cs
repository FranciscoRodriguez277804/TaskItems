﻿namespace WebApplication1.Models
{
    public class TaskItems
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool  IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
