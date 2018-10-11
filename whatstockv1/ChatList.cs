using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatstockv1
{
    class ChatList
    {

        private String key_remote_jid, subject;
        private double timestamp, creation, id;
        public ChatList(String key_remote_jid, String subject, double timestamp, double creation, double id)
        {
            this.key_remote_jid = key_remote_jid;
            this.subject = subject;
            this.timestamp = timestamp;
            this.creation = creation;
            this.id = id;
        }
        public ChatList()
        {
            this.key_remote_jid = "";
            this.subject = "";
            this.timestamp = -1;
            this.creation = -1;
            this.id = -1;

        }

        internal Contact contient
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public String getKey_remote_jid()
        {
            return key_remote_jid;
        }
        public void setKey_remote_jid(String key_remote_jid)
        {
            this.key_remote_jid = key_remote_jid;
        }
        public String getSubject()
        {
            return subject;
        }
        public void setSubject(String subject)
        {
            this.subject = subject;
        }
        public double getTimestamp()
        {
            return timestamp;
        }
        public void setTimestamp(double timestamp)
        {
            this.timestamp = timestamp;
        }
        public double getCreation()
        {
            return creation;
        }
        public void setCreation(double creation)
        {
            this.creation = creation;
        }
        public double getId()
        {
            return id;
        }
        public void setId(double id)
        {
            this.id = id;
        }
    public String toString()
        {
            return "ChatList [key_remote_jid=" + key_remote_jid + ", subject=" + subject + ", timestamp=" + timestamp
                    + ", creation=" + creation + ", id=" + id + "]";
        }

    }
}
