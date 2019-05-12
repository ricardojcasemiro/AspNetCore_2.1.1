using FN.Store.UI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Data
{
    public interface IDataContext
    {
        string GetStringConn();

        DbSet<Produto> Produtos { get; set; }
    }
}
