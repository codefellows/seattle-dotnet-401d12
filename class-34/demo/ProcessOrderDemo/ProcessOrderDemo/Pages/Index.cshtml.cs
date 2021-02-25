using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProcessOrderDemo.Services.Email.Interfaces;
using ProcessOrderDemo.Services.Email.Models;

namespace ProcessOrderDemo.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public Player player { get; set; }

    [BindProperty]
    public string status { get; set; }

    public IEmail emailService { get; }

    public IndexModel(IEmail service)
    {
      emailService = service;
    }

    public void OnGet()
    {
    }

    public async Task OnPost()
    {

      // Authorize the credit card
      // If it was good ... and we have their money ...
      // THEN send the emails and update the cart to be "done"

      // SendEmailAsync ... to, subject, message
      Message message = new Message()
      {
        To = player.Email,
        Subject = $"Welcome to the team, {player.Name}",
        Body = $"<p>Can't wait to see you playing {player.Position} wearing {player.Number}!",
      };

      EmailResponse response = await emailService.SendEmailAsync(message);

      status = response.WasSent.ToString();

      player.Name = string.Empty;
      player.Email = string.Empty;
      player.Position = string.Empty;
      player.Number = null;
    }

    public class Player
    {
      [Required]
      public string Name { get; set; }
      [Required]
      public string Email { get; set; }
      [Required]
      public string Position { get; set; }
      [Required]
      public int? Number { get; set; }
    }
  }
}
