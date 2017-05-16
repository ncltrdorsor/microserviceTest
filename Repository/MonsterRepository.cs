using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetTest.Repository
{
    public class MonsterRepository : IMonsterRepository
    {
        private static ICollection<Monster> monsters;

        public MonsterRepository()
        {
            if (monsters == null)
            {
                monsters = new List<Monster>(); 
            }
        }

        public List<Monster> All()
        {
            var monsters = new List<Monster>() { new Monster { ID = Guid.NewGuid(), Name = "Potato" } };
            return monsters;
        }
    }
}
