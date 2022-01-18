namespace usos.API.Application.Models.Auth
{
  public class SetPasswordRequest
  {
    public string NewPassword { get; set; }
    
    public string NewPasswordConfirm { get; set; }
  }
}