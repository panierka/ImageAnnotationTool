using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnnotationToolDataAccessLibrary.Exceptions
{
    public class JobDoesNotExistException : Exception
    {
        public JobDoesNotExistException(int jobID)
            : base($"Team with given id '{jobID}' does not exists") { }
    }
}