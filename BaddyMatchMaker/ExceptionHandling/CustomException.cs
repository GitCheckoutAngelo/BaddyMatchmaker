using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaddyMatchMaker.ExceptionHandling
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, int id) : base($"Entity {entity} with id {id} could not be found")
        {
        }
    }

    public class DuplicateKeyException : Exception
    {
        public DuplicateKeyException(string entity, int id) : base($"Entity {entity} with id {id} already exists in the database")
        {
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
