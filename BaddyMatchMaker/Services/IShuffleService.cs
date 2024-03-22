using System.Collections.Generic;

namespace BaddyMatchMaker.Services
{
    public interface IShuffleService
    {
        void Shuffle<T>(IList<T> list);
    }
}
