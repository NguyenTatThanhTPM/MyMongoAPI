using System.ComponentModel.DataAnnotations;


namespace MyMongoApi.Models;

public class BookDto
{
    public string Id { get; set; } = string.Empty;
    [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
    [MinLength(3, ErrorMessage = "Tiêu đề phải có ít nhất 3 ký tự")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tác giả không được bỏ trống")]
    [MinLength(3, ErrorMessage = "Tác giả phải có ít nhất 3 ký tự")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = "Detail không được bỏ trống")]
    [MinLength(3, ErrorMessage = "Detail phải có ít nhất 3 ký tự")]
    public string Detail { get; set; } = string.Empty;
  
        
    
}
