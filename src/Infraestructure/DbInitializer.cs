using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Domain.Interface;
using System.Collections.Generic;

namespace Infraestructure.Data
{
    public static class DbInitialize
    {
        public static void Seed(this IContext context)
        {
            context.Database.EnsureCreated();

            // // Look for any students.

            var categoriesList = new List<Category>();
            if (!context.Categories.Any())
            {
                var Categories = new Category[]
                {
                    new Category{Id = Guid.NewGuid(), Name="administracao", Description="Administração"},
                    new Category{Id = Guid.NewGuid(), Name="agricultura", Description="Agricultura"},
                    new Category{Id = Guid.NewGuid(), Name="antropologia", Description="Antropologia"},
                    new Category{Id = Guid.NewGuid(), Name="arqueologia", Description="Arqueologia"},
                    new Category{Id = Guid.NewGuid(), Name="arquitetura", Description="Arquitetura"},
                    new Category{Id = Guid.NewGuid(), Name="artes", Description="Artes"},
                    new Category{Id = Guid.NewGuid(), Name="astronomia", Description="Astronomia"},
                    new Category{Id = Guid.NewGuid(), Name="biologia", Description="Biologia"},
                    new Category{Id = Guid.NewGuid(), Name="botanica", Description="Botânica"},
                    new Category{Id = Guid.NewGuid(), Name="brasil", Description="Brasil"},
                    new Category{Id = Guid.NewGuid(), Name="ciencia-politica", Description="Ciência Política"},
                    new Category{Id = Guid.NewGuid(), Name="ciencias-exatas", Description="Ciências Exatas"},
                    new Category{Id = Guid.NewGuid(), Name="cinema", Description="Cinema"},
                    new Category{Id = Guid.NewGuid(), Name="comunicacao", Description="Comunicação"},
                    new Category{Id = Guid.NewGuid(), Name="contabilidade", Description="Contabilidade"},
                    new Category{Id = Guid.NewGuid(), Name="decoracao", Description="Decoração"},
                    new Category{Id = Guid.NewGuid(), Name="dicionarios", Description="Dicionários"},
                    new Category{Id = Guid.NewGuid(), Name="didaticos", Description="Didáticos"},
                    new Category{Id = Guid.NewGuid(), Name="direito", Description="Direito"},
                    new Category{Id = Guid.NewGuid(), Name="documentos", Description="Documentos"},
                    new Category{Id = Guid.NewGuid(), Name="ecologia", Description="Ecologia"},
                    new Category{Id = Guid.NewGuid(), Name="economia", Description="Economia"},
                    new Category{Id = Guid.NewGuid(), Name="engenharia", Description="Engenharia"},
                    new Category{Id = Guid.NewGuid(), Name="enciclopedias", Description="Enciclopédias"},
                    new Category{Id = Guid.NewGuid(), Name="ensino-de-idiomas", Description="Ensino de Idiomas"},
                    new Category{Id = Guid.NewGuid(), Name="filosofia", Description="Filosofia"},
                    new Category{Id = Guid.NewGuid(), Name="fotografia", Description="Fotografia"},
                    new Category{Id = Guid.NewGuid(), Name="geografia", Description="Geografia"},
                    new Category{Id = Guid.NewGuid(), Name="guerra", Description="Guerra"},
                    new Category{Id = Guid.NewGuid(), Name="historia-do-brasil", Description="História do Brasil"},
                    new Category{Id = Guid.NewGuid(), Name="historia-geral", Description="História Geral"},
                    new Category{Id = Guid.NewGuid(), Name="informatica", Description="Informática"},
                    new Category{Id = Guid.NewGuid(), Name="linguistica", Description="Linguística"},
                    new Category{Id = Guid.NewGuid(), Name="medicina", Description="Medicina"},
                    new Category{Id = Guid.NewGuid(), Name="moda", Description="Moda"},
                    new Category{Id = Guid.NewGuid(), Name="musica", Description="Música"},
                    new Category{Id = Guid.NewGuid(), Name="pecuaria", Description="Pecuária"},
                    new Category{Id = Guid.NewGuid(), Name="pedagogia", Description="Pedagogia"},
                    new Category{Id = Guid.NewGuid(), Name="pintura", Description="Pintura"},
                    new Category{Id = Guid.NewGuid(), Name="psicologia", Description="Psicologia"},
                    new Category{Id = Guid.NewGuid(), Name="saude", Description="Saúde"},
                    new Category{Id = Guid.NewGuid(), Name="sociologia", Description="Sociologia"},
                    new Category{Id = Guid.NewGuid(), Name="teatro", Description="Teatro"},
                    new Category{Id = Guid.NewGuid(), Name="turismo", Description="Turismo"},
                    new Category{Id = Guid.NewGuid(), Name="biografias", Description="Biografias" },
                    new Category{Id = Guid.NewGuid(), Name="colecoes", Description="Coleções" },
                    new Category{Id = Guid.NewGuid(), Name="comportamento", Description="Comportamento" },
                    new Category{Id = Guid.NewGuid(), Name="contos", Description="Contos" },
                    new Category{Id = Guid.NewGuid(), Name="critica-literaria", Description="Crítica Literária" },
                    new Category{Id = Guid.NewGuid(), Name="ficcao-cientifica", Description="Ficção Científica" },
                    new Category{Id = Guid.NewGuid(), Name="folclore", Description="Folclore" },
                    new Category{Id = Guid.NewGuid(), Name="genealogia", Description="Genealogia" },
                    new Category{Id = Guid.NewGuid(), Name="humor", Description="Humor" },
                    new Category{Id = Guid.NewGuid(), Name="infanto-juvenis", Description="Infantojuvenis" },
                    new Category{Id = Guid.NewGuid(), Name="jogos", Description="Jogos" },
                    new Category{Id = Guid.NewGuid(), Name="jornais", Description="Jornais" },
                    new Category{Id = Guid.NewGuid(), Name="literatura-brasileira", Description="Literatura Brasileira" },
                    new Category{Id = Guid.NewGuid(), Name="literatura-estrangeira", Description="Literatura Estrangeira" },
                    new Category{Id = Guid.NewGuid(), Name="livros-raros", Description="Livros Raros" },
                    new Category{Id = Guid.NewGuid(), Name="manuscritos", Description="Manuscritos" },
                    new Category{Id = Guid.NewGuid(), Name="Poesia", Description="Poesia" },
                    new Category{Id = Guid.NewGuid(), Name="outros-assuntos", Description="Outros Assuntos" }
                };
                categoriesList = Categories.ToList();
                context.Categories.AddRange(Categories);
            }

            // List<ApplicationRole> lists = new List<ApplicationRole>();
            // var myRoles = lists;
            // if (!context.Roles.Any())
            // {
            //     var Roles = new Role[]
            //     {

            //     };
            //     context.Roles.AddRange(Roles);
            //     myRoles = Roles.ToList();
            // }
            // if (!context.Users.Any())
            // {

            //     var users = new User[]
            //     {
            //         // senha é teste123
            //         new User { Id = Guid.NewGuid(),
            //                 Name = "Administrador",
            //                 Cpf = "99999999999",
            //                 Username = "admin",
            //                 Email = "admin@gmail.com" ,
            //                 Password = "2242461295221015719538209212227614317113501631961762",
            //                 Role= context.Roles.Any()? context.Roles.FirstOrDefault(x=> x.Id.ToString() == "2A367317-7BF8-45A2-89D5-74B8E8D54D3B").Name : myRoles.FirstOrDefault().Name
            //         },
            //     };

            //     context.Users.AddRange(users);

            //     var UserRole = myRoles.Any() ? myRoles.FirstOrDefault() : context.Roles.FirstOrDefault(x => x.Id.ToString() == "2A367317-7BF8-45A2-89D5-74B8E8D54D3B");

            //     var userRole = new UserRole(users.AsQueryable().FirstOrDefault(), UserRole);
            //     context.UserRoles.Add(userRole);
            // }

            if (!context.Books.Any() && context.Categories.Any() || categoriesList.Any())
            {

                var categoryI = context.Categories.Any() ? context.Categories.FirstOrDefault() : categoriesList.FirstOrDefault();

                var books = new Book[]
                {
                    new Book { Id = Guid.NewGuid(), Title = "Dom Quixote", Author = "Miguel de Cervantes", Year = "1605", Description = "Um dos maiores clássicos da literatura espanhola, Dom Quixote conta a história de um cavaleiro que leu demasiados romances e enlouqueceu. Dom Quixote agora pensa que é um herói, como nos livros que leu, e sai em busca de aventuras com seu leal escudeiro, Sancho Pança. Esse livro cômico inspirou muitas outras sátiras ao longo da História.", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "Guerra e Paz", Author = "Liev Tolstói", Year = "1869",Description = "Se prepare mentalmente, porque este livro é gigante! A obra-prima de Tolstói conta a história de 5 famílias aristocráticas na Rússia e como foram afetadas pela invasão de Napoleão. Entre intrigas, romances, batalhas e surpresas, esse livro é um verdadeiro épico da literatura russa.", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "A Montanha Mágica", Author = "Thomas Mann", Year = "1924",Description = "A Montanha Mágica é um livro escrito por Thomas Mann em 1924. Um dos romances mais influentes da literatura mundial do século XX, foi importante para a conquista do Prêmio Nobel de Literatura em 1929 por Mann. É um exemplo clássico da literatura que os alemães classificam como Bildungsroman", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "Cem Anos de Solidão", Author = "Gabriel García Márquez", Year = "1967",Description = "", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "Ulisses", Author = "James Joyce", Year = "1922",Description = "O clássico poema épico de Homero é sem sombra de dúvidas uma literatura fundamental para quem gostaria de ler as obras mais importantes já escritas do mundo. Esta é a continuação da Ilíada, escrita também pelo autor grego. Em Odisseia, Homero relata o regresso de Odisseu, ou Ulisses, para Ítaca após a guerra de Tróia.", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "Em Busca do Tempo Perdido", Author = "Marcel Proust", Year = "1913",Description = "Sete livros constituem a saga de Em Busca do Tempo Perdido do escritor francês Marcel Proust. Considerado por muitos como uma das maiores influências literárias do Século XX, os livros foram traduzido no Brasil por autores como Carlos Drummond de Andrade e Manuel Bandeira. Terminar este clássico que em sua edição de bolso possui mais de 3.500 páginas é uma longa jornada, mas com toda certeza, valerá a pena", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "A Divina Comédia", Author = "Dante Alighieri",Description = "", Year = "1321", Category = category },
                    new Book { Id = Guid.NewGuid(), Title = "O Banquete - Platão",Author = "Miguel de Cervantes", Year = "2009",Description = "A República de Platão é sem dúvida o livro mais conhecido do filósofo grego. Contudo, o Banquete, também conhecido como Simpósio, é de longe, o mais belo. Nesta conversa, Platão vai discutir as naturezas do amor e da alma. Um clássico da filosofia escrito por volta de 380 A.C e que ecoa até hoje quando falamos de um tema universal: o amor.", Category = category }
                };
                context.Books.AddRange(books);
            }
            //     foreach (Permissao p in permissoes)
            //     {
            //         context.Permissoes.Add(p);
            //         i++;
            //     }   

            //     i = 0;                
            //     foreach (Permissao p in permissoes)
            //     {
            //         var up = new UsuarioPermissao(users[i], p);
            //         context.UsuarioPermissoes.Add(up);
            //         i++;
            //     }   


            // }

            // if (!context.Fornecedores.Any())
            // {

            //     for(int i = 0; i < 5; i++)
            //     {
            //         context.Fornecedores.Add(new Fornecedor { Id = Guid.NewGuid(), Nome = $"Fornecedor {i}", CnpjCpf = gerador(), Email= $"fornecedor,{i}@email.com",Telefone=$"{gerador(9)}"});
            //     }


            context.SaveChanges();
        }

        private static string gerador(int leng = 10)
        {
            Random R = new Random();
            return ((long)R.Next(0, 100000) * (long)R.Next(0, 100000)).ToString().PadLeft(leng, '0');
        }
    }
}