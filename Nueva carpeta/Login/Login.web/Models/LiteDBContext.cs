using System;
using LiteDB;
using Microsoft.Extensions.Options;

namespace Login.web.Models
{
    public class LiteDBContext
    {
        public readonly LiteDatabase Context;
        public LiteDBContext(IOptions<LiteDBConfig> configs)
        {
            try
            {
                var db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                    Context = db;
            }
            catch (Exception ex)
            {
                throw new Exception("No se encuentra o no se puede crear LiteDB.", ex);
            }
        }
    }
}
