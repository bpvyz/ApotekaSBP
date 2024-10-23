using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ApotekaLibrary.Mapiranja;
using System;

namespace ApotekaLibrary
{
    internal class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static readonly object objLock = new object();

        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                    {
                        _factory = CreateSessionFactory();
                    }
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                            .ShowSql()
                            .ConnectionString(c =>
                                c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S18922;Password=S18922"));

                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZaposleniMapiranja>())
                    .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating session factory: {ex.Message}");
                throw;
            }
        }
    }
}
