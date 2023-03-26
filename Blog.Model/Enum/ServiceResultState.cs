using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    [Serializable]
    public enum ServiceResultState
    {
        ERROR = 0,
        SUCCESS = 1,
        WARNING = 2
    }
}
