using System.ComponentModel.DataAnnotations;

namespace Storage.API.Entities;

public interface ITrackable
{
  public DateTime UpdatedAt { get; set; }
}
