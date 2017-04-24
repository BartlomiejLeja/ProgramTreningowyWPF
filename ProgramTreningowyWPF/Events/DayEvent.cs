using Prism.Events;
using ProgramTreningowyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTreningowyWPF.Events
{
    class DayEvent : PubSubEvent<PersonNoTreningDaySet>
    {
    
    }

    class WorkOutDayEvent : PubSubEvent<PersonTreningDaySet>
    {

    }

    class IsActive : PubSubEvent<bool>
    {

    }
    class LoginString : PubSubEvent<string>
    {

    }
    class ErrorString : PubSubEvent<string>
    {

    }
    class WrongLoginString : PubSubEvent<string>
    {

    }
    class RegisterString : PubSubEvent<string>
    {

    }
    class RestDayAddString : PubSubEvent<string>
    {

    }
}
