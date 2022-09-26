using MovieRatingExample.Core.Service;

namespace MovieRatingExample.Application;

public class ReviewService : IReviewService
{
    public int GetNumberOffReviewsFromReviwer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateFromReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfReviews(int movie)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateOfMovie(int movie)
    {
        throw new NotImplementedException();
    }

    public int GetNumberOfRates(int movie, int rate)
    {
        throw new NotImplementedException();
    }

    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        throw new NotImplementedException();
    }

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewerByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}