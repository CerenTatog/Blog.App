﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
    public class CommentsViewModel
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string DateStr { get; set; }

        public string UserProfileFoto { get; set; }

        public string CommentText { get; set; }
    }
}
