using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using WebApplication2.Utils;

namespace WebApplication2.Services
{
    public class LutadorService : IFases
    {
        public List<Lutador> listarLutadores()
        {
            List<Lutador> lutadores = new List<Lutador>();

            var t = Task.Run(() => TSClient.GetAllFighters());
            t.Wait();

            lutadores = t.Result;

            return lutadores;
        }

        public Lutador comecarLutas(List<Lutador> escolhidos)
        {
            var ordenados = escolhidos.OrderBy(x => x.Idade).ToList();
            var vencedoresOitavas = oitavasDeFinal(ordenados);
            var vencedoresQuartas = quartasDeFinal(vencedoresOitavas);
            var vencedoresSemi = semiDeFinal(vencedoresQuartas);
            var vencedor = final(vencedoresSemi);
            
            return vencedor;
        }

        private Lutador lutar(Lutador lutador1, Lutador lutador2)
        {
            if (calcularPorcentagemVitorias(lutador1) > calcularPorcentagemVitorias(lutador2))
                return lutador1;
            else if (calcularPorcentagemVitorias(lutador1) < calcularPorcentagemVitorias(lutador2))
                return lutador2;
            else
                return criterioDesempate(lutador1, lutador2);

        }

        private int calcularPorcentagemVitorias(Lutador lutador)
        {
            return lutador.Vitorias / (lutador.Lutas * 100);
        }

        private Lutador criterioDesempate(Lutador lutador1, Lutador lutador2)
        {
            if (lutador1.ArtesMarciais.Count > lutador2.ArtesMarciais.Count)
                return lutador1;
            else if (lutador1.ArtesMarciais.Count < lutador2.ArtesMarciais.Count)
                return lutador2;
            else if (lutador1.Lutas > lutador2.Lutas)
                return lutador1;
            else
                return lutador2;

        }

        public List<Lutador> oitavasDeFinal(List<Lutador> lutadoresEscolhidos)
        {
            List<Lutador> vencedores = new List<Lutador>();
            for (int i = 0; i < lutadoresEscolhidos.Count; i += 2)
            {
               vencedores.Add(lutar(lutadoresEscolhidos[i], lutadoresEscolhidos[i + 1]));
            }

            return vencedores;
        }

        public List<Lutador> quartasDeFinal(List<Lutador> lutadoresVencedores)
        {
            List<Lutador> vencedores = new List<Lutador>();
            for (int i = 0; i < lutadoresVencedores.Count; i += 2)
            {
                vencedores.Add(lutar(lutadoresVencedores[i], lutadoresVencedores[i + 1]));
            }

            return vencedores;
        }

        public List<Lutador> semiDeFinal(List<Lutador> lutadoresVencedores)
        {
            List<Lutador> vencedores = new List<Lutador>();
            for (int i = 0; i < lutadoresVencedores.Count; i += 2)
            {
                vencedores.Add(lutar(lutadoresVencedores[i], lutadoresVencedores[i + 1]));
            }

            return vencedores;
        }

        public Lutador final(List<Lutador> lutadoresVencedores)
        {
            Lutador vencedor = new Lutador();
            for (int i = 0; i < lutadoresVencedores.Count; i += 2)
            {
                vencedor = lutar(lutadoresVencedores[i], lutadoresVencedores[i + 1]);
            }

            return vencedor;
        }
    }
}