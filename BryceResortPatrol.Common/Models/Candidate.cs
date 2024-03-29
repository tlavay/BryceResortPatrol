﻿namespace BryceResortPatrol.Common.Models;

public record Candidate
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return @$"
                Id: {Id}, 
                FirstName: {FirstName},
                LastName: {LastName},
                Email: {Email},
                PhoneNumber: {PhoneNumber},
                Description: {Description}";
    }
}
