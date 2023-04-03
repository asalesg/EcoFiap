namespace EcoFiap.Repository.Context
{
    using Fiap.Web.AspNet.Models;
    using Fiap.Web.AspNet.Repository.Context;

    namespace Fiap.Web.AspNet.Repository
    {
        public class UsuarioRepository
        {

            private readonly DataBaseContext dataBaseContext;

            public UsuarioRepository(DataBaseContext ctx)
            {
                dataBaseContext = ctx;
            }



            public IList<UsuarioModel> Listar()
            {
                var lista = new List<UsuarioModel>();

                // Efetuando a listagem (Substituindo o Select *)
                lista = dataBaseContext.Usuario.ToList<UsuarioModel>();

                return lista;
            }

            public UsuarioModel Consultar(int id)
            {
                // Recuperando o objeto Usuario de um determinado Id
                var Usuario = dataBaseContext.Usuario.Find(id);

                return Usuario;
            }

            public void Inserir(UsuarioModel Usuario)
            {
                // Adiciona o objeto preenchido pelo usuário
                dataBaseContext.Usuario.Add(Usuario);

                // Salva as alterações
                dataBaseContext.SaveChanges();

            }

            public void Alterar(UsuarioModel Usuario)
            {
                dataBaseContext.Usuario.Update(Usuario);

                // Salva as alterações
                dataBaseContext.SaveChanges();
            }

            public void Excluir(int id)
            {
                var Usuario = new UsuarioModel(id, "");

                dataBaseContext.Usuario.Remove(Usuario);

                // Salva as alterações
                dataBaseContext.SaveChanges();

            }


        }
    }
}
