using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatterns.WPFClient.Models;

namespace Vavatech.DesignPatterns.WPFClient.IServices
{
    interface IPersonsService
    {
        Person Get(int id);
    }
}
