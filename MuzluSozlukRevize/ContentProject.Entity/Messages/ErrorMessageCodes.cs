using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Entity.Messages
{
    public enum ErrorMessageCode
    {
        UserNameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEmail = 153,
        UserAlreadyActive = 154,
        ActivateIdDoesNotExists = 155,
        UserNotFound = 156,
        ProfileCouldNotUpdated = 157,
        UserCouldNotRmove = 158,
        UserCouldNotFind = 159,
        UserCouldNotInserted = 160
    }
}
