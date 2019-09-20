using System.Collections.Generic;
using System.Linq;
using AttendanceSample.Entity;
using AttendanceSample.Repository.Interface;
using AttendanceSample.Service.Interface;
using AttendanceSample.Service.DTO;


namespace AttendanceSample.Service.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IUnitOfWork unitOfWork, IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }

        public Movie GetMovieInfo(int id)
        {
            return _movieRepository.GetById(id);
        }

        public List<Movie> GetAllMovie()
        {
            return _movieRepository.GetAllWithGenre().ToList();
            //return _movieRepository.GetAll().ToList();
        }

        public bool CreateMovie(MovieDto movie)
        {
            //TODO: auto mapper here

            var entity = new Movie
            {
                Name = movie.Name,
                GenreId = movie.GenreId
            };
            return _movieRepository.Insert(entity);
        }

        public bool UpdateMovie(Movie movie)
        {
            return _movieRepository.Update(movie);
        }

        #region Sample Code
        public bool SampleTransactionMethod()
        {
            _unitOfWork.Begin();
            try
            {
                //Your database code here
                _genreRepository.Insert(new Genre { Name = "Sci-fi" });
                _movieRepository.Insert(new Movie { Name = "Test", GenreId = 1 });

                _unitOfWork.Commit();
                return true;
            }
            catch
            {
                _unitOfWork.Rollback();
                return false;
            }
        }
        #endregion

    }
}