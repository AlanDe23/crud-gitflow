using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTrut.Application.DTOs;

namespace WebTrut.Application.Interfaces
{
     public  interface IAnalisisUrlService
    {


        Task<AnalisisResultadoDto> AnalizarSitioWebAsync(string url);
    }
}
