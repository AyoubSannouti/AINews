using AINews.Application.Features.ArticleCategories.Commands.Create_ArticleCategory;
using AINews.Application.Features.ArticleCategories.Commands.Delete_ArticleCategory;
using AINews.Application.Features.ArticleCategories.Commands.Update_ArticleCategory;
using AINews.Application.Features.Articles.Commands.CreateArticle;
using AINews.Application.Features.Articles.Commands.UpdateArticle;
using AINews.Application.Features.Articles.Queries.GetArticleDetail;
using AINews.Application.Features.Articles.Queries.GetArticlesList;
using AINews.Application.Features.Authentication.Commands.Login;
using AINews.Application.Features.Authentication.Commands.Register;
using AINews.Application.Features.EventCategories.Commands.CreateEventCategory;
using AINews.Application.Features.EventCategories.Commands.DeleteEventCategory;
using AINews.Application.Features.EventCategories.Commands.UpdateEventCategory;
using AINews.Application.Features.Events.Commands.CreateEvent;
using AINews.Application.Features.Events.Commands.UpdateEvent;
using AINews.Application.Features.Events.Queries.GetEventDetail;
using AINews.Application.Features.Events.Queries.GetEventsList;
using AINews.Domain.Entities;
using AutoMapper;

namespace AINews.Application.Profiles
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Article, GetArticlesListViewModel>().ReverseMap();
            CreateMap<Article, GetArticleDetailViewModel>().ReverseMap();
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
            CreateMap<Article, UpdateArticleCommand>().ReverseMap();

            CreateMap<Event, GetEventsListViewModel>().ReverseMap();
            CreateMap<Event, GetEventDetailViewModel>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap(); 
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

            CreateMap<ArticleCategory, CreateArticleCategoryCommand>().ReverseMap();
            CreateMap<ArticleCategory, DeleteArticleCategoryCommand>().ReverseMap();
            CreateMap<ArticleCategory, UpdateArticleCategoryCommand>().ReverseMap();

            CreateMap<EventCategory, CreateEventCategoryCommand>().ReverseMap();
            CreateMap<EventCategory, DeleteEventCategoryCommand>().ReverseMap();
            CreateMap<EventCategory, UpdateEventCategoryCommand>().ReverseMap();
        }
    }
}
