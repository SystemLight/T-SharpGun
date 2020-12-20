using System.Collections.Generic;
using System.Linq;
using SharpGun.Models;

namespace SharpGun.Services
{
    public interface IElvesRepositoryService
    {
        public IEnumerable<Elves> GetAllElves();
        public Elves GetElvesById(int id);
    }

    public class ElvesRepositoryService : IElvesRepositoryService
    {
        private List<Elves> _elves;

        public ElvesRepositoryService() {
            InitializeNoodle();
        }

        private void InitializeNoodle() {
            _elves = new List<Elves>
            {
                new Elves {Id = 1, Name = "a", Age = 12},
                new Elves {Id = 2, Name = "b", Age = 13},
                new Elves {Id = 3, Name = "c", Age = 14}
            };
        }

        public IEnumerable<Elves> GetAllElves() {
            return _elves;
        }

        public Elves GetElvesById(int id) {
            return _elves.FirstOrDefault(n => n.Id == id);
        }
    }
}
