﻿namespace UserApiControlerAvi.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; } = [];
        public List<Transaction>? Transactions { get; set; }
    }
}
