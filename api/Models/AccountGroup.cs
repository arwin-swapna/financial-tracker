using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class AccountGroup
  {
    public int Id { get; set; }
    public string AccessToken { get; set; }
    public virtual List<Account> Accounts { get; set; }
    public virtual User User { get; set; }
  }
}