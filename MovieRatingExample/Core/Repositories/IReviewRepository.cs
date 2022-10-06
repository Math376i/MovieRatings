using MovieRatingExample.Core.Model;

namespace MovieRatingExample.Core.Repositories;


/// <summary>
/// Interface implements GetAll from BEReview
/// </summary>
public interface IReviewRepository
{
    List<BEReview> GetAll();
}