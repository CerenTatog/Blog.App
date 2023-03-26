using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public enum ArticleStatusEnum
    {
        Draft,
        Published,
        Passive,
    }
}
