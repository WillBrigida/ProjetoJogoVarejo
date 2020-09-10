using JogoVarejo_Server.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo_Server
{
    public static class Mock
    {
        public async static Task<List<Grupo>> ListaGrupo()
        {
            var list = new List<Grupo>
            {
                new Grupo {Quanto = "Teste1", Quando = "Teste1", GrupoId = 1, GrupoOperador = 5},
                new Grupo {Quanto = "Teste2", Quando = "Teste2", GrupoId = 2, GrupoOperador = 4},
                new Grupo {Quanto = "Teste3", Quando = "Teste3", GrupoId = 3, GrupoOperador = 3},
                new Grupo {Quanto = "Teste4", Quando = "Teste4", GrupoId = 4, GrupoOperador = 2},
                new Grupo {Quanto = "Teste5", Quando = "Teste5", GrupoId = 5, GrupoOperador = 1},
            };

            return await Task.Run(() => { return list; });
        }

        public async static Task<Grupo> ListaGrupo(int id)
        {
            var list = new List<Grupo>
            {
                new Grupo {Quanto = "Teste1", Quando = "Teste1", GrupoId = 1, GrupoOperador = 5},
                new Grupo {Quanto = "Teste2", Quando = "Teste2", GrupoId = 2, GrupoOperador = 4},
                new Grupo {Quanto = "Teste3", Quando = "Teste3", GrupoId = 3, GrupoOperador = 3},
                new Grupo {Quanto = "Teste4", Quando = "Teste4", GrupoId = 4, GrupoOperador = 2},
                new Grupo {Quanto = "Teste5", Quando = "Teste5", GrupoId = 5, GrupoOperador = 1},
            };

            return await Task.Run(() => { return list.Where(x => x.GrupoId == id).FirstOrDefault(); });
        }

        //public async static Task<List<Movimento>> Historico(int id)
        //{
        //    var list = new List<Movimento>
        //    {   
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},
        //        new Movimento {Dia = 1, Recebido = 30, AReceber = 30, SaldoInicial = 30, Comprado = 20, Prazo = 3, Demanda = 7, Vendido = 5, SaldoFinal = 6, SaldoMedioDia = 9},

        //    };

        //    return await Task.Run(() => { return list; });
        //}

        public async static Task<Indicadores> ListaIndicadores(int id)
        {
            var list = new List<Indicadores>
            {
                new Indicadores
                {
                    GrupoId = 1,
                    ClientesAtendidos = 18, Ganho = 10, ClientesPerdidos = 3, GanhoPerdido = 50, NivelServiçoCliente = 5,
                    EstoqueMed = 5, CobEstoqueMed = 20, CustoEstocar = 40, Giro = 30,
                    EstoqueMax = 40, CobEstoqueMax = 40, CapitalEstoqueMax = 60, NumEncomendas = 10, CustoFrete  = 40, NivelServiçoSupr = 7,
                    GanhoPotencial = 6, CustoGerenciado = 20, CustoFixo = 10, Lucro = 10, Lucratividade = 40,

                },
                new Indicadores{GrupoId = 2, ClientesAtendidos = 27, Ganho = 10, ClientesPerdidos = 3, GanhoPerdido = 50, NivelServiçoCliente = 5},
                new Indicadores{GrupoId = 3, ClientesAtendidos = 52, Ganho = 10, ClientesPerdidos = 3, GanhoPerdido = 50, NivelServiçoCliente = 5},
                new Indicadores{GrupoId = 4, ClientesAtendidos = 30, Ganho = 10, ClientesPerdidos = 3, GanhoPerdido = 50, NivelServiçoCliente = 5},
            };

            return await Task.Run(() => { return list.Where(x => x.GrupoId == id).FirstOrDefault(); });
        }


        public async static Task<Movimento> ListaMovimentos(int id)
        {
            var list = new List<Movimento>
            {
                new Movimento {MovimentoId = 1, GrupoId = 1, AReceber = 3, Comprado = 9, 
                    Demanda = 20, Dia = 8, Prazo = 4, Recebido = 2, SaldoFinal = 9, SaldoInicial = 4, SaldoMedioDia = 3, Vendido = 8},

                new Movimento {MovimentoId = 2, GrupoId = 3, AReceber = 3, Comprado = 9,
                    Demanda = 20, Dia = 8, Prazo = 4, Recebido = 2, SaldoFinal = 9, SaldoInicial = 4, SaldoMedioDia = 3, Vendido = 8},

                new Movimento {MovimentoId = 1, GrupoId = 1, AReceber = 3, Comprado = 9,
                    Demanda = 20, Dia = 8, Prazo = 4, Recebido = 2, SaldoFinal = 9, SaldoInicial = 4, SaldoMedioDia = 3, Vendido = 8},
            };

            return await Task.Run(() => { return list.Where(x => x.GrupoId == id).FirstOrDefault(); });
        }
    }
}