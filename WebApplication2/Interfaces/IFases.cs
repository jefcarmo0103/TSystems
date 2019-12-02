using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Interfaces
{
    interface IFases
    {
        List<Lutador> oitavasDeFinal(List<Lutador> lutadoresEscolhidos);
        List<Lutador> quartasDeFinal(List<Lutador> lutadoresVencedores);
        List<Lutador> semiDeFinal(List<Lutador> lutadoresVencedores);
        Lutador final(List<Lutador> lutadoresVencedores);
    }
}
