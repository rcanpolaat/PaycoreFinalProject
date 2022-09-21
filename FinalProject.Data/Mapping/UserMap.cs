using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace FinalProject.Data
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Email, x =>
            {
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Password, x =>
            {
                x.Length(20);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.LastActivity, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });


            Table("user");
        }
    }
}
