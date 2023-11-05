using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Senders.Mail
{
  public interface ISendMail
  {
    public void Send(string to, string subject, string body);
  }
}
