using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;

namespace MovieRatingExample.Application;

public class ReviewService : IReviewService
{
    private IReviewRepository Repository;

    public ReviewService(IReviewRepository repository)
    {
        if (repository == null)
        {
            throw new AggregateException("You are missing the repository");
        }

        Repository = repository;
    }
    
    
    public int GetNumberOffReviewsFromReviwer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public double GetAverageRateFromReviewer(int reviewer)
    {
        int count = 0;
        foreach (BEReview review in Repository.GetAll())
        {
            if (review.Reviewer == reviewer)
                count++;
        }

        return count;
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