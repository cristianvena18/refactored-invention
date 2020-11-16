using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpFinal.Models;

namespace TpFinal.Data
{
    public class Seeder
    {
        private DatabaseConnection connection;

        public Seeder(DatabaseConnection connection) { this.connection = connection; }

        public void SeedData(ModelBuilder modelBuilder)
        {
            var adventure = new Genre() { Id = 4, Description = "Adventure" };
            var animation = new Genre() { Id = 5, Description = "Animation" };
            var drama = new Genre() { Id = 6, Description = "Drama" };
            var romance = new Genre() { Id = 7, Description = "Romance" };

            connection.Genres.AddRange(new List<Genre>
                {
                    adventure, animation, drama, romance
                });

            var jimCarrey = new Person() { Id = 5, Name = "Jim Carrey", Birthdate = new DateTime(1962, 01, 17), Biography = "Jim Carrey, es un humorista, actor y cantante canadiense nacionalizado estadounidense. Es conocido por sus interpretaciones con humor slapstick,3​ y por su trabajo ganó dos Premios Globo de Oro y fue candidato a un Premio BAFTA." };
            var robertDowney = new Person() { Id = 6, Name = "Robert Downey Jr.", Birthdate = new DateTime(1965, 4, 4), Biography = "Robert John Downey Jr. es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York. Se mudó con su padre a California, pero abandonó sus estudios para enfocarse completamente en su carrera." };
            var chrisEvans = new Person() { Id = 7, Name = "Chris Evans", Birthdate = new DateTime(1981, 06, 13), Biography = "Chris Evans, es un actor, director y productor estadounidense. Criado en el pueblo de Sudbury, Evans mostró interés a temprana edad por la actuación y luego de terminar la secundaria, se mudó a Nueva York para estudiar teatro." };

            connection.People.AddRange(new List<Person>
                {
                    jimCarrey, robertDowney, chrisEvans
                });

            var endgame = new Film()
            {
                Id = 2,
                Title = "Avengers: Endgame",
                Outstanding = true,
                ReleaseDate = new DateTime(2019, 04, 26)
            };

            var iw = new Film()
            {
                Id = 3,
                Title = "Avengers: Infinity Wars",
                Outstanding = false,
                ReleaseDate = new DateTime(2019, 04, 26)
            };

            var sonic = new Film()
            {
                Id = 4,
                Title = "Sonic the Hedgehog",
                Outstanding = false,
                ReleaseDate = new DateTime(2020, 02, 28)
            };
            var emma = new Film()
            {
                Id = 5,
                Title = "Emma",
                Outstanding = false,
                ReleaseDate = new DateTime(2020, 02, 21)
            };
            var greed = new Film()
            {
                Id = 6,
                Title = "Greed",
                Outstanding = false,
                ReleaseDate = new DateTime(2020, 02, 21)
            };

            connection.Films.AddRange(new List<Film>
                {
                    endgame, iw, sonic, emma, greed
                });

            connection.MoviesGenres.AddRange(
                new List<MoviesGenres>()
                {
                    new MoviesGenres(){FilmId = endgame.Id, GenreId = drama.Id},
                    new MoviesGenres(){FilmId = endgame.Id, GenreId = adventure.Id},
                    new MoviesGenres(){FilmId = iw.Id, GenreId = drama.Id},
                    new MoviesGenres(){FilmId = iw.Id, GenreId = adventure.Id},
                    new MoviesGenres(){FilmId = sonic.Id, GenreId = adventure.Id},
                    new MoviesGenres(){FilmId = emma.Id, GenreId = drama.Id},
                    new MoviesGenres(){FilmId = emma.Id, GenreId = romance.Id},
                    new MoviesGenres(){FilmId = greed.Id, GenreId = drama.Id},
                    new MoviesGenres(){FilmId = greed.Id, GenreId = romance.Id},
                });


            connection.MoviesActors.AddRange(
                new List<MoviesActors>()
                {
                    new MoviesActors(){FilmId = endgame.Id, PersonId = robertDowney.Id, Character = "Tony Stark", Order = 1},
                    new MoviesActors(){FilmId = endgame.Id, PersonId = chrisEvans.Id, Character = "Steve Rogers", Order = 2},
                    new MoviesActors(){FilmId = iw.Id, PersonId = robertDowney.Id, Character = "Tony Stark", Order = 1},
                    new MoviesActors(){FilmId = iw.Id, PersonId = chrisEvans.Id, Character = "Steve Rogers", Order = 2},
                    new MoviesActors(){FilmId = sonic.Id, PersonId = jimCarrey.Id, Character = "Dr. Ivo Robotnik", Order = 1}
                });

            connection.SaveChanges();
        }
    }
}
