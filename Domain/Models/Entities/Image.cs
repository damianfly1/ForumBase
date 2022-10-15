﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities;

public class Image
{
    public Image(byte[] data)
    {
        Data = data;
    }

    public Image()
    {
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastUpdatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public byte[] Data { get; set; }
}
