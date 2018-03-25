using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerenciador_Aniversario.Models
{
    public class Calculator
    {
        public static int DiasRestantesAniversario(DateTime dt)
        {
            int anoAtual = DateTime.Today.Year;

            var dataInicial = DateTime.Today;
            var dataFinal = $"{dt.Day}/{dt.Month}/{anoAtual}";
            var days = (DateTime.Parse(dataFinal).Subtract(dataInicial)).Days;

            if (days <= 0)
            {
                days = (DateTime.Parse(dataFinal).AddYears(1).Subtract(dataInicial)).Days;
            } 

            return days;
        }
    }
}