using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Entities.Models;

namespace WebLibrary.Entities.Interfaces
{
    public interface ILoanService
    {
        string RegisterLoan(string bookId, ALoan loan);
    }
}