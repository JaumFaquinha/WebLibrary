using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Entities.Models;

namespace WebLibrary.Entities.Interfaces
{
    public interface IBookService
    {
        List<ABook> GetAll();
        ABook GetById(string id);
        ABook Create(ABook book);
        ABook Update(string id, ABook book);
        string Delete(string id);
        List<ABook> Search(string query);
        List<ABook> GetTopBooks();
    }
}