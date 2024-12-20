﻿using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendBox(string p);
        void MessageAdd(Message message);
        Message GetByID(int id);

        void MessageDelete(Message message);
        void MesssageUpdate(Message message);
    }
}
