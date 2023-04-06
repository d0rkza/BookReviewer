using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.IBusiness
{
    public interface IBookReviewerService
    {
        //Register functionality that is avaialable to any class that uses BookReviewerService
        void CheckUserPermissions(string username);
        
    }
}
