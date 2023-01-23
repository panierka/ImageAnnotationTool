using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Exceptions
{
    public class TeamDoesNotExistException : Exception
    {
        public TeamDoesNotExistException(int teamID)
            : base($"Team with given id '{teamID}' does not exists") { }
    }
}