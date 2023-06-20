using AutoMapper;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Core.Models.Report;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Core.Models.Questions.Question, Data.Models.Question.Question>().ReverseMap();

            CreateMap<QuestionDetailsView, QuestionListItem>().ReverseMap();

            CreateMap<CorporateQnA.Core.Models.Report.Report, CorporateQnA.Data.Models.Report.Report>().ReverseMap();
        }
    }
}
   