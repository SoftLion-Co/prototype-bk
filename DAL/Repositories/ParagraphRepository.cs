using DAL.Context;
using DAL.Entities;
using DAL.GenericRepository;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ParagraphRepository : GenericRepository<Paragraph>, IParagraphRepository
    {
        public ParagraphRepository(DataContext context) : base(context)
        {
        }
    }
}