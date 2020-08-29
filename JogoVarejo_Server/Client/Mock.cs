using JogoVarejo_Server.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JogoVarejo_Server
{
    public static class Mock
    {
        public async static Task<List<Grupo>> ListaGrupo()
        {
            var list =  new List<Grupo>
            {
                new Grupo {Como = "Teste1", Quando = "Teste1", GrupoId = 1, GrupoOperadorId = 5},
                new Grupo {Como = "Teste2", Quando = "Teste2", GrupoId = 2, GrupoOperadorId = 4},
                new Grupo {Como = "Teste3", Quando = "Teste3", GrupoId = 3, GrupoOperadorId = 3},
                new Grupo {Como = "Teste4", Quando = "Teste4", GrupoId = 4, GrupoOperadorId = 2},
                new Grupo {Como = "Teste5", Quando = "Teste5", GrupoId = 5, GrupoOperadorId = 1},
            };

            return await Task.Run(()=> {return list;});
        }

         public async static Task<List<Historico>> Historico(int id)
        {
            var list =  new List<Historico>
            {
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
                new Historico {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},

            };

            return await Task.Run(()=> {return list;});
        }
    }
}