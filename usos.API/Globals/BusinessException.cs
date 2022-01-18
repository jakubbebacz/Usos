using System;

namespace usos.API.Globals
{
  public class BusinessException : Exception
  {
    public string Code { get; }
    
    public BusinessException(string message, string code = null) : base(message)
    {
      Code = code;
    }

    public BusinessException(string message, Exception ex) : base(message, ex)
    {
    }

    public override string ToString()
    {
      return $"Handled Business Exception: {Message}";
    }
  }
}
