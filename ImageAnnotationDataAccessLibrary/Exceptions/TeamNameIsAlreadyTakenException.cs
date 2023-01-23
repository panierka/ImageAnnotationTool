using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Exceptions
{
    public class TeamNameIsAlreadyTakenException : Exception
    {
        public TeamNameIsAlreadyTakenException(string teamName)
            : base($"Team with given name '{teamName}' already exists") { }
    }
}
