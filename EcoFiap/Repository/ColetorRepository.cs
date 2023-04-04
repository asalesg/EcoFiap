using EcoFiap.Models;
using EcoFiap.Repository.Context;

namespace EcoFiap.Repository
{


    public class ColetorRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public ColetorRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<ColetorModel> Listar()
        {
            var lista = new List<ColetorModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Coletor.ToList<ColetorModel>();

            return lista;
        }

        public ColetorModel Consultar(int id)
        {
            // Recuperando o objeto Coletor de um determinado Id
            var Coletor = dataBaseContext.Coletor.Find(id);

            return Coletor;
        }

        public void Inserir(ColetorModel Coletor)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Coletor.Add(Coletor);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(ColetorModel Coletor)
        {
            dataBaseContext.Coletor.Update(Coletor);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var Coletor = new ColetorModel();

            dataBaseContext.Coletor.Remove(Coletor);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }

}