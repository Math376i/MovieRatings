﻿using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;

namespace MovieRatingExample.Application;

public class ReviewService : IReviewService
{
    private IReviewRepository Repository;
    List<double> grades;

    public ReviewService(IReviewRepository repository)
    {
        if (repository == null)
        {
            throw new AggregateException("You are missing the repository");
        }

        Repository = repository;
    }
    
    public int GetNumberOfReviewsFromReviewer(int reviewer)
    {
        int count = 0;
        foreach (BEReview review in Repository.GetAll())
        {
            if (review.Reviewer == reviewer)
                count++;
        }
        return count;
    }
    
    public double GetAverageRateFromReviewer(int reviewer)
    {
        foreach (BEReview n in Repository.GetAll())
        {
            grades.Add(n.Grade);
        }
        return grades.Average() ;
    }

    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        int count = 0;
        foreach (BEReview grade in Repository.GetAll())
        {
            if (grade.Reviewer == reviewer)
                count++;
        }
        return count;    
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