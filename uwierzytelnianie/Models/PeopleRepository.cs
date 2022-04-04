using uwierzytelnianie.Data;

namespace uwierzytelnianie.Models
{
    public class PeopleRepository
    {
        private readonly PeopleContext _context;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }

        public List<Person> Search(string NameTerm, string SurnameTerm)
        {
            if (string.IsNullOrEmpty(NameTerm) && string.IsNullOrEmpty(SurnameTerm))
            {
                return _context.Person.OrderByDescending(o => o.DateTime).ToList();
            }
            else if (string.IsNullOrEmpty(NameTerm))
            {
                return _context.Person.Where(o => o.Surname.StartsWith(SurnameTerm)).OrderByDescending(o => o.DateTime).ToList();
            }
            else if (string.IsNullOrEmpty(SurnameTerm))
            {
                return _context.Person.Where(o => o.Name.StartsWith(NameTerm)).OrderByDescending(o => o.DateTime).ToList();
            }
            else
            {
                return _context.Person.Where(o => o.Name.StartsWith(NameTerm) &&
                    o.Surname.StartsWith(SurnameTerm)).OrderByDescending(o => o.DateTime).ToList();
            }
        }
    }
}
