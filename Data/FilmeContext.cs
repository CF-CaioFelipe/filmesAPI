using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
//Foi baixando:
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Tools
//MySql.Microsoft.EntityFrameworkCore
//e Depois criado a pasta Data com uma classe chamada "FilmeContext"

{
    public class FilmeContext : DbContext //Herda da DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt): base(opt)  //Contrutor que pega a base de opt
        {

        }

        public DbSet<Filme> Filmes{ get; set; }
    }
}
