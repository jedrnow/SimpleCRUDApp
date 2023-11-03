﻿namespace SimpleCRUDApp.Models.Input
{
    public record CreateUserInput
    {
        public string Name { get; init; }
        public string Phone { get; init; }
        public string Email { get; init; }
    }
}
