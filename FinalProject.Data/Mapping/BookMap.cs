using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FinalProject.Data
{
    public class BookMap : ClassMapping<Book>
    {
        public BookMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Name, x =>
            {
                x.Length(100);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Description, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.CategoryId, x => 
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.Color, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Brand, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Price, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.IsOfferable, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(b => b.IsSold, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });


            Table("book");
        }
    }
}
